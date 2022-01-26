using Microsoft.EntityFrameworkCore;
using ShoesHouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Data.Extensions
{
    public static class ModelBuiderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Nike",
                    Description = "All the must-have releases from Nike, " +
                    "with everything from icons like the Nike Air Force 1 and Nike Air Max line," +
                    " to Nike SB, to the latest in-demand collaborations from the famous footwear brand known and loved across the globe."
                },
                 new Category
                 {
                     Id = 2,
                     Name = "Adidas",
                     Description = "The \"Brand with the 3 Stripes\" is a legend, " +
                     "birthing classics from the Stan Smith to the Superstar before reinventing itself with NMD, " +
                     "Ultra Boost, and its Yeezy collection."
                 },
                 new Category
                 {
                     Id = 3,
                     Name = "New Balance",
                     Description = "Known for premium quality and ultimate comfort," +
                     " New Balance is one of the world’s premier athletic footwear brands. " +
                     "Find a full range of the New England-based brand’s retro runners," +
                     " modern hits, and coveted collaborations here."
                 },
                 new Category
                 {
                     Id = 4,
                     Name = "Converse",
                     Description = "More than a century of established excellence."
                 },
                  new Category
                  {
                      Id = 5,
                      Name = "Vans",
                      Description = "Live \"Off The Wall\" with Vans Old Skools, Vans Slip-Ons, and more."
                  },
                  new Category
                  {
                      Id = 6,
                      Name = "Asics",
                      Description = "Retro classics like the Gel-Lyte III and much more."
                  }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Nike Dunk High “Dark Curry” ",
                    Description = "The Nike Dunk High “Dark Curry” puts an appealing lifestyle look on the timeless high-top shoe. " +
                    "The “Dark Curry” was released in March 2021 and exemplifies Nike’s efforts of expanding the Dunk’s footprint in sneakers. " +
                    "A year earlier, in 2020, the Nike Dunk re-emerged from relative obscurity to once again capture the attention of sneaker collectors due to an impressive amount of limited edition collaborations and returning retro colorways." +
                    "As for the design of the “Dark Curry,” hairy orange-brown suede overlays on the model’s forefoot, eyelets, collar, and heel contrast the black brushed suede base. " +
                    "A darker shade of brown suede can be found on the Swoosh branding on either side and on the small pull tab on the heel. Nike layers brown laces over the black mesh tongue and adds a midsole for a timeless look. Underfoot, a tan outsole finishes off the look of the “Dark Curry.” ",
                    Stock = 1,
                    Size = 42,
                    CategoryId = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 2500000
                },
                new Product
                {
                    Id = 2,
                    Name = "Pharrell - Billionaire Boys Club - Astronaut Blue ",
                    Description = "The BBC x Pharrell x adidas NMD Hu “Astronaut Blue” is a November 2021 collaboration between the Virginia native, his streetwear brand, and adidas on the former’s popular signature shoe. This three-way collaboration between Billionaire Boys Club, Pharrell, and adidas brings a neutral-colored look to the NMD Hu. The “Astronaut Blue” features BBC’s signature “Astronaut” branding on its design, specifically on the top of both the left and right shoe. The upper is constructed from a Halo Blue-colored sweater-like material, the same ribbed knit upper that is also found on the adidas NMD Hu’s “Cream” colorway. The shoe is constructed in a slip-on-like style with wraparound laces incorporated into the translucent midfoot cage found on either side. BBC’s “Astronaut” logo appears on the back of the left shoe while adidas’s Trefoil logo is found on the back of the right shoe. Underfoot, a responsive Boost midsole completes the look.",
                    Size = 41,
                    CategoryId = 2,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 2100000
                },
                new Product
                {
                    Id = 3,
                    Name = "Salehe Bembury - Water Be The Guide",
                    Description = "The Salehe Bembury x New Balance 2002R is the second highly coveted collaboration by the footwear and fashion designer and New Balance. As its nickname implies, the colorway is inspired by water, the source of life for us all, and is colored accordingly with a refreshing aqua blue hairy suede upper. Premium brown leather detailing is found on the tongue and at the ankle, while the light tan mesh base adds plenty of breathability. Shearling N logos in green add another earthy vibe. New Balance's NERGY foam midsole provides a light and cushioned feel all day long",
                    Size = 42,
                    CategoryId = 3,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 2400000
                },
                new Product
                {
                    Id = 4,
                    Name = "Run Star Hike",
                    Description = "The Converse Run Star Hike Hi gives the classic Chuck Taylor design an edgy twist with its chunky platform style and jagged sole. The upper remains untouched from its original style with the black canvas construction, white rubber toe cap, and Chuck Taylor emblem. Meanwhile, the bottom introduces a new look with a two-tone outsole and thick platform that remains true to its iconic roots. This iteration lends a fashion-forward appeal and modern vibe.",
                    Size = 42,
                    CategoryId = 4,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 1300000
                },
                 new Product
                 {
                     Id = 5,
                     Name = "Vans attitude Notre - White",
                     Description = "The Notre x Vans OG Old Skool LX \"White\" is one of several colorways of the classic lifestyle shoe created by the Chicago clothing and sneaker boutique and Vans for Fall 2020. The Vans OG Old Skool LX receives several updates in design from its venerable Old Skool relative, including a new premium suede construction, a padded leather collar, and cream, vulcanized midsole. Here, on the Notre-designed “White” colorway, hairy cream suede can be found on the entire upper. Notre places its signature handshake logo on either side in place of the Old Skool’s signature wavy detailing. A black “Vans” branded license plate resides on the heel of the cream sole",
                     Size = 42,
                     CategoryId = 5,
                     DateCreated = DateTime.Now,
                     OriginalPrice = 1600000
                 },
                  new Product
                  {
                      Id = 6,
                      Name = " Asics Concepts - Otoro",
                      Description = "The Concepts x ASICS GEL-Lyte III \"Otoro\" is a collaborative sneaker that exemplifies storytelling at its finest. Symbolic of the Bluefin Tuna and its highly acclaimed belly fat called “Otoro,” this special-edition shoe updates the Gel-Lyte III silhouette with premium pigskin suede in various shades of pink—which is a nod to the beautiful color of the fish. Reflective accents represent sushi tools used to eat the delectable dish. To commemorate the collaboration, a Concepts logo is debossed into the lateral heel area",
                      Size = 42,
                      CategoryId = 6,
                      DateCreated = DateTime.Now,
                      OriginalPrice = 2000000
                  },
                   new Product
                   {
                       Id = 7,
                       Name = "Asics Gel Excite 7 Men's Running",
                       Description = "These Asics Gel Excite 7 Men's Running Shoes have been crafted with an AmpliFoam midsole which delivers a flexible and tactile ride as well as offering exceptional cushioning with every stride. The breathable mesh fabric upper allows your feet to remain cool and comfortable throughout your run, whilst the GEL technology helps absorb shock and adds further cushioning for a comfortable running experience.",
                       Size = 42,
                       CategoryId = 6,
                       DateCreated = DateTime.Now,
                       OriginalPrice = 1900000
                   },
                    new Product
                    {
                        Id = 8,
                        Name = "Palladium Pampa Lite Overlab Neon",
                        Description = "Palladium Pampa Lite Overlab Neon for active and on-the-go young people, made from a combination of two high-quality waterproof polyester and ballistic mesh fabrics. In addition, it comes with an outsole that uses advanced Lite - Tech technology to help reduce the weight of the shoes significantly. Vibrant neon colors along with brand details give the design a striking trendy look, with a trendy look and setting it apart from the crowd.",
                        Size = 42,
                        CategoryId = 4,
                        DateCreated = DateTime.Now,
                        OriginalPrice = 1700000
                    },
                     new Product
                     {
                         Id = 9,
                         Name = "Nike Air Max 98 South Beach",
                         Description = "White leather/rubber Air Force 1 '07 Craft sneakers from NIKE featuring round toe, flat rubber sole, front lace - up fastening, branded insole, signature Swoosh logo detail and perforated design.These styles are supplied by a premium sneaker marketplace.Stocking only the most sought - after footwear, they source and curate some of the most hard to find sneakers from around the world",
                         Size = 42,
                         CategoryId = 1,
                         DateCreated = DateTime.Now,
                         OriginalPrice = 2300000
                     }
             );

        }
    }
}
