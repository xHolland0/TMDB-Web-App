using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TMDB.Models;

namespace TMDB.ViewModels
{
    public class VM_Movie
    {
        public int Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad Alanı'nı Boş Geçemezsiniz.")]
        [StringLength(50, ErrorMessage = "Ad Maksimum 50 Karakterden Oluşabilir.")]
        public string Name { get; set; }



        [DisplayName("Çıkış Tarihi")]
        [Required(ErrorMessage = "Çıkış Tarihi'ni Boş Geçemezsiniz.")]
        public string ReleaseYear { get; set; }



        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama Alanı'nı Boş Geçemezsiniz.")]
        [MaxLength(1000, ErrorMessage = "Açıklama Maksimum 1000 Karakterden Oluşabilir.")]
        [MinLength(3, ErrorMessage = "Açıklama Minimum 3 Karakterden Oluşabilir.")]
        public string Description { get; set; }

        [DisplayName("Trend Film")]
        [Required(ErrorMessage = "Yeni Ürün Alanı'nı Boş Geçemezsiniz.")]
        public bool IsPopular { get; set; }

        [DisplayName("Yeni Film")]
        [Required(ErrorMessage = "Yeni Ürün Alanı'nı Boş Geçemezsiniz.")]
        public bool IsNew { get; set; }

        [DisplayName("Bu Hafta Çıkış Yapmış")]
        [Required(ErrorMessage = "Yeni Ürün Alanı'nı Boş Geçemezsiniz.")]
        public bool ThisWeek { get; set; }


        [DisplayName("Kullanıcı Puanı")]
        [Required(ErrorMessage = "UserPoint Alanı'nı Boş Geçemezsiniz.")]
        public int UserPoint { get; set; }


        [DisplayName("Kategori Id")]
        [Required(ErrorMessage = "Kategori Alanı'nı Boş Geçemezsiniz.")]
        public int CategoryId { get; set; }

        public List<SelectListItem> CategorySelectList { get; set; } = new List<SelectListItem>();

 
    }
}
