using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary
{
    public class GarageModel
    {
        public int Id { get; set; } //nr
        [DisplayName("Tytuł")]
        public string Title { get; set; } // tytuł
        [DataType(DataType.DateTime)]
        [DisplayName("DataDodania")]
        public DateTime ReleaseDate { get; set; } //Data wstawienia obiektu
        [DisplayName("Cena")]
        public decimal Price { get; set; } //cena
        [DisplayName("Kolor")]
        public string TextureFront { get; set; }// rodzaj malowania stali

        [DisplayName("Kolor")]
        public string TextureRoof { get; set; }// rodzaj malowania stali
        [DisplayName("Kolor")]
        public string TextureWall { get; set; }// rodzaj malowania stali
        [DisplayName("Szerokość")]
        public int Front_x { get; set; } //szerokosc
        [DisplayName("Wysokość")]
        public int Front_y { get; set; } //wysokosc
        [DisplayName("Długość")]
        public int Right_x { get; set; } //dlugosc obiektu
        [DisplayName("Wysokość Dachu")]
        public int Roof_hight { get; set; } // wysokość dachu
        [DisplayName("Komentarz")]
        public string Comment { get; set; }// komentarz
        [DisplayName("Brama Pierwsza")]
        public string Gate_1 { get; set; } //rodziaj bramy
        [DisplayName("Brama Druga")]
        public string Gate_2 { get; set; } //rodziaj bramy



        public bool IsComplite { get; set; }

    }
    public class PfotoGModel
    {
        public int GarazId { get; set; }
        //Klasa z nazwami zdjęć //
        public string Pfoto_1 { get; set; }
        public string Pfoto_2 { get; set; }
        public string Pfoto_3 { get; set; }
        public string Pfoto_4 { get; set; }
        public string Pfoto_5 { get; set; }
        public string Pfoto_6 { get; set; }

        public string AddFolderImage(string FolderPatch ,string FolderName, string ImageName)//string z lokalizacją 
        {
            return FolderPatch+"/"+FolderName+"/"+ImageName;
        }
        //Nie potrzebne//
        public void AddAllfolderPictures(string FolderName) //dodanie ścieżdki gdzie są zdjęcia zapisane tylko nazwa folderu
        {
            if (Pfoto_1 != null)
            {
                Pfoto_1 = FolderName + "/" + Pfoto_1;
            }
            if (Pfoto_2 != null)
            {
                Pfoto_2 = FolderName + "/" + Pfoto_2;
            }
            if (Pfoto_3 != null)
            {
                Pfoto_3 = FolderName + "/" + Pfoto_3;
            }
            if (Pfoto_4 != null)
            {
                Pfoto_4 = FolderName + "/" + Pfoto_4;
            }
            if (Pfoto_5 != null)
            {
                Pfoto_5 = FolderName + "/" + Pfoto_5;
            }
            if (Pfoto_6 != null)
            {
                Pfoto_6 = FolderName + "/" + Pfoto_6;
            }
        }
    }

}
