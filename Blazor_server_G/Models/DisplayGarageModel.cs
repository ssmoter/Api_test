using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_server_G.Models
{
    public class DisplayGarageModel
    {
        public int Id { get; set; } //nr
        [DisplayName("Tytuł")]
        public string Title { get; set; } // tytuł
        [DataType(DataType.Date)]
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
    }
}
