using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            return _open[i,j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i,j];
        }

        public bool Percolate()
        {
            return _percolate;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> voisins = new List<KeyValuePair<int, int>>();

            // Ajout du voisin en fonction des différents cas possibles
            if(i > 0)
            {
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
            }
            if (i < _size - 1)
            {
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
            }
            if (j > 0)
            {
                voisins.Add(new KeyValuePair<int, int>(i, j - 1));
            }
            if (j < _size - 1)
            {
                voisins.Add(new KeyValuePair<int, int>(i, j + 1));
            }
            return voisins;
        }

        public void Open(int i, int j)
        {
            List<KeyValuePair<int, int>> voisins = CloseNeighbors(i, j);

            //Ouverture de case
            _open[i, j] = true;

            //On remplit une case lorsqu'elle se trouve en première ligne
            if(i==0)
            {
                _full[i, j] = true;
            }

            //Si la case possède un voisin plein, on procède au remplissage
            foreach (KeyValuePair<int,int> voisin in voisins)
            {
                if(IsFull(voisin.Key,voisin.Value))
                {
                    _full[i, j] = true;

                    //Si on remplit une case de la dernière ligne, il y a percolation
                    if(voisin.Key == _size - 1)
                    {
                        _percolate = true;
                    }

                    // On remplit toutes les cases vides et ouvertes voisines à la qui vient d'être remplie
                    Remplir(i, j);
                }
            }

        }

        private void Remplir(int i,int j)
        {
            List<KeyValuePair<int, int>> voisins = CloseNeighbors(i, j);

            foreach (KeyValuePair<int, int> voisin in voisins)
            {
                if(IsOpen(voisin.Key,voisin.Value) && !IsFull(voisin.Key,voisin.Value))
                {
                    //On remplit le voisin qui est ouvert et vide
                    _full[voisin.Key, voisin.Value] = true;

                    //Si on remplit une case de la dernière ligne, il y a percolation
                    if (voisin.Key == _size - 1)
                    {
                        _percolate = true;
                    }

                    //On appelle à nouveau la méthode en recursif
                    Remplir(voisin.Key, voisin.Value);
                }
            }
        }
    }
}
