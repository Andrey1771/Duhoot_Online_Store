using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public enum TypeCard
    {
        House, Human, Education, Music, Transport
    }

    public class ProductSiteCard
    {
        public ProductSiteCard()
        {
            DateTimeAdded = DateTime.Now;
        }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Название продукта")]
        public virtual string Title { get; set; }

        [Display(Name = "Текст под продуктом")]
        public virtual string Text { get; set; }

        [Display(Name = "Картинка на фоне")]
        public virtual string BackgroundImage { get; set; }

        [Display(Name = "Дополнительный текст в овале")]
        public virtual string RightTopText { get; set; }

        [Display(Name = "Рейтинг продукта")]
        public virtual int Rating { get; set; }// TODO Необходимо реализовать расчет этих параметров в зависимости от Оценок пользавтелей

        [Display(Name = "Количество комментариев")]
        public virtual int CountComments { get; set; }//

        [Display(Name = "Тип карты продукта")]
        public virtual TypeCard TypeCard { get; set; }


        public DateTime DateTimeAdded { get; set; }


        public bool IsEmpty()
        {
            if ((Product, ProductId, Title, Text, BackgroundImage,
                RightTopText, Rating, CountComments, TypeCard, DateTimeAdded) == default)
                return true;
            return false;
        }

    }
}
