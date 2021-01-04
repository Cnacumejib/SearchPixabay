using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPixabay.Entities
{
    public enum pi_lang:int
    {
        ru = 0, en, cs, da, de, es, fr, id, it, hu, nl, no, pl, pt, ro, sk, fi, sv, tr, vi, th, bg, el, ja, ko, zh
    }

    public enum pi_order
    {
        popular,
        latest,
    }

    public enum pi_color : int
    {
        grayscale = 1,
        transparent,
        red,
        orange,
        yellow,
        green,
        turquoise,
        blue,
        lilac,
        pink,
        white,
        gray,
        black,
        brown
    }

    public enum pi_category : int
    {
        backgrounds = 1,
        fashion,
        nature,
        science,
        education,
        feelings,
        health,
        people,
        religion,
        places,
        animals,
        industry,
        computer,
        food,
        sports,
        transportation,
        travel,
        buildings,
        business,
        music
    }
    public enum pi_image_type : int
    {
        all = 0,
        photo,
        illustration,
        vector
    }
    public enum pi_orientation : int
    {
        all = 0,
        horizontal,
        vertical
    }
}
