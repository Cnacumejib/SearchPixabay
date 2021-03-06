﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.IO;
using WordPressSharp;
using WordPressSharp.Models;

using SearchPixabay.Entities;
using SearchPixabay.IWAContracts;
using SearchPixabay.WebAccessor;


namespace SearchPixabay.WordpressImageFiller
{
    class Program
    {
        private static IWebAccessorContracts pixabayAccessor = new PixabayAccessor();
        static void Main(string[] args)
        { 
            WordPressSiteConfig wordpressSiteConfig = new WordPressSiteConfig();
            wordpressSiteConfig.BaseUrl = "https://virtualtales.com/";
            wordpressSiteConfig.Username = "3nKMcBUjgtR49kRVo3mpQ";
            wordpressSiteConfig.Password = @"MM0m#q81cP&X2BQuYKm$e";
            int addedCounter = 0;
            int missedCounter = 0;
            using (var client = new WordPressClient(wordpressSiteConfig))
            {
                PostFilter postFilter = new PostFilter() { PostType = "post" };    //записи с типом post
                Post[] posts = client.GetPosts(postFilter);
                for (int i = 0; i < posts.Length; i++)
                {
                    /*     if (!posts[i].Title.Contains("test"))
                         {
                             //пропускам не тестовые  --- !!!!!!!!!!!!!!!       УДАЛИТЬ     !!!!!!!!!!!!!!!
                             continue;
                         }
                    */
                    if (posts[i].HasFeaturedImage())
                    {
                        //пропускаем посты с картинкой
                        continue;
                        // posts[i].FeaturedImage = null;
                    }

                    List<string> tags = new List<string>();
                    foreach (Term term in posts[i].Terms)
                    {
                        if (term.Taxonomy == "post_tag")
                        {
                            tags.Add(term.Name);//лучше Slug
                        }
                    }

                    string fileId = string.Empty;
                    if (tags.Any())
                    {
                        IEnumerable<WebImage> webImages = GetWebImages(tags);
                        foreach (WebImage webImage in webImages)
                        {
                            try
                            {
                                Data featureImage = Data.CreateFromUrl(webImage.Url);
                                featureImage.post_id = int.Parse(posts[i].Id);
                                fileId = client.UploadFile(featureImage).Id;
                                if (!string.IsNullOrEmpty(fileId))
                                {
                                    pixabayAccessor.AddUsedImage(webImage);
                                    break;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }

                        posts[i].FeaturedImageId = fileId;
                        client.EditPost(posts[i]);
                        addedCounter++;
                    }
                    else
                    {
                        // не нашли ярлыков в посте
                        Console.WriteLine($"Post \"{posts[i].Title}\" has not any post_tags");
                        missedCounter++;
                    }
                }
            }

            Console.WriteLine($"new feature images added: {addedCounter}{Environment.NewLine}posts without post_tags: {missedCounter}");
            Console.WriteLine($"{Environment.NewLine}press any key.");
            Console.ReadLine();
        }

        private static IEnumerable<WebImage> GetWebImages(List<string> tags)
        {

            int count = tags.Count();
            IEnumerable<WebImage> images = pixabayAccessor.GetImagePages(tags);
            if (images.Any() || count==1)
            {
                return images;
            }

            List<string> removedTags = new List<string>();
            while (count > 1)
            {
                removedTags.Add(tags[count - 1]);
                tags.RemoveAt(count-1);
                images = pixabayAccessor.GetImagePages(tags);
                if (images.Any())
                {
                    return images;
                }

                count = tags.Count();
            }

            removedTags.Reverse();
            foreach (string tag in removedTags)
            {
                images = pixabayAccessor.GetImagePages(new string[] { "tags" });
                if (images.Any())
                {
                    return images;
                }
            }

            return images;
        }
    }
}