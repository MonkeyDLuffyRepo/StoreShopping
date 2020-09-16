using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace TestCodding
{
    class Program
    {
        static void Main(string[] args)
        {
            var lignes = new[] { "Ayoub", "Amine", "Mohammed" };
            Console.WriteLine("Hello World!");
            ITraitement traitService = new Numerotation();
            var result = traitService.Traite(lignes);
            var collections = result.ToArray();
            for (int i = 0; i < collections.Count(); i++)
            {
                Console.WriteLine(collections[i]);
            }
          

        }
    }

    public interface ITraitement
    {
        IEnumerable<string> Traite(IEnumerable<string> source);
        string TraiteLigne(string ligne);
    }

    public class TraitementBase : ITraitement
    {
        public IEnumerable<string> Traite(IEnumerable<string> source)
        {
            var collections = source.ToArray();


            for (int i = 0; i < collections.Count(); i++)
            {
                collections[i] = TraiteLigne(collections[i]);
            }
            return collections;
        }
        public string TraiteLigne(string ligne)
        {
            return String.Concat(ligne.Reverse());
        }
    }

    public class Inversion : TraitementBase
    {

    }

    public class Numerotation : ITraitement
    {
        private int prefix = 0;
        private string getCurrentPrefix()
        {
            var result = prefix.ToString().PadLeft(5, '0');
            prefix++;
            return result;
        }
        public IEnumerable<string> Traite(IEnumerable<string> source)
        {
            if (source == null) return null;

            var collections = source.ToArray();


            for (int i = 0; i < collections.Count(); i++)
            {
                collections[i] = TraiteLigne(collections[i]);
            }
            return collections;
        }

        public string TraiteLigne(string ligne)
        {
            if (ligne == null) return null;
            return getCurrentPrefix() + ":" + ligne;
        }
    }

    public class Change
    {
        public long coin2 = 0;
        public long bill5 = 0;
        public long bill10 = 0;
    }

    class Solution
    {
        public static Change OptimalChange(long s)
        {
            var change = new Change();

            change.bill10 = s / 10;
            var rest = s % 10;
            if(rest%5 == 0)
            {
                change.bill5 = 1;
                return change;
            }
            if(rest % 2 == 0)
            {
                change.coin2 = rest / 2;
                return change;
            }
            if(rest > 5 && rest % 2 == 1)
            {
                change.bill5 = 1;
                var rest2 = rest % 5;
                change.coin2 = rest2 / 2;
                return change;
            }
            return null;
        }
    }
}
