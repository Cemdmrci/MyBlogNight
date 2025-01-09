using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.EntityLayer.Concrete
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CoverImageUrl { get; set; }
        public string MainImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } //Burası veritabına yansımayacak bu ilişkideki bir boyutu için Burası sayesinde kategori sınıfına erişim sağlayabiliyorum.
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } //1-SpordaBugün-Yazar:@item.AppUser.Name bu name ulaşmak için lazım appuser
        public String Detail { get; set; }
        public int? ArticleViewCount { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
