using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ITinnovDesign.Storefront.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return String.Format("${0}", price);
        }

        public static int Recherche_Lineaire_Vecteur_Ordonne(int[] vecteur, int valeurRecherche)
        {
            for (int i = 0; i < vecteur.Length; i++)
            {
                if (valeurRecherche == vecteur[i])
                {
                    return i;
                }
                else if (vecteur[i] > valeurRecherche)
                {
                    break;
                }
            }

            return -1;
        }


        public static int Recherche_Bineaire_Vecteur_Ordonne(int[] vecteur, int valeurRecherche)
        {
            int indexDebut = 0;
            int indexFin = vecteur.Length - 1;
            int indexMilieu;
            int valeurIndexMilieu;
            while (indexDebut <= indexFin)
            {
                indexMilieu = (indexDebut + indexFin) / 2;
                valeurIndexMilieu = vecteur[indexMilieu];

                if (valeurRecherche == valeurIndexMilieu)
                {
                    return indexMilieu;
                }
                else if (valeurRecherche < valeurIndexMilieu)
                {
                    indexFin = indexMilieu - 1;
                }
                else if (valeurRecherche > valeurIndexMilieu)
                {
                    indexDebut = indexMilieu + 1;
                }
            }
            return -1;
        }
    }
}
