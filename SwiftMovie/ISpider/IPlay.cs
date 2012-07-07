using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ISpider
{
    public interface IPlay
    {
        List<Play> getPlays(string html);
    }
}
