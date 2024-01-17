using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TMDB.ViewModels
{
    public class VM_FreeMovie
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




        [DisplayName("Yeni Film")]
        [Required(ErrorMessage = "Yeni Film Alanı'nı Boş Geçemezsiniz.")]
        public bool IsNew { get; set; }



        [DisplayName("Bu Hafta Çıkış Yapmış")]
        [Required(ErrorMessage = "Bu Hafta Çıkış Yapmı Alanı'nı Boş Geçemezsiniz.")]
        public bool ThisWeek { get; set; }

        

        [DisplayName("İzlemesi Ücretsiz")]
        [Required(ErrorMessage = "İzlemesi Ücretsiz Film Alanı'nı Boş Geçemezsiniz.")]
        public bool IsFree { get; set; }


        [DisplayName("Kullanıcı Puanı")]
        [Required(ErrorMessage = "UserPoint Alanı'nı Boş Geçemezsiniz.")]
        public int UserPoint { get; set; }


        [DisplayName("Kategori Id")]
        [Required(ErrorMessage = "Kategori Alanı'nı Boş Geçemezsiniz.")]

        public int CategoryId { get; set; }

        public List<SelectListItem> CategorySelectList { get; set; } = new List<SelectListItem>();

 
    }
}
