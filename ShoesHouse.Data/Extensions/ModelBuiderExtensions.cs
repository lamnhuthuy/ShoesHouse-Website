using Microsoft.AspNetCore.Identity;
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
                         OriginalPrice = 1750000
                     },
                       new Product
                       {
                           Id = 10,
                           Name = "Joe Freshgoods x New Balance 990V3 Outside Clothes",
                           Description = "The Joe Freshgoods x New Balance 990V3 “Outside Clothes” is the much anticipated follow up to the Chicago native’s heralded collaboration with the Boston footwear company on the 992 “No Emotions Are Emotions” from 2020. The “Outside Clothes” colorway of the classic 990V3 was released in limited quantities exclusively in Joe Freshgoods’ hometown of Chicago at Garfield Park where he grew up. Accompanied by an advertisement directed by Mike Carson and scored by Alchemist that explains the origins of the design, the multicolor look features beige suede overlays atop an aqua mesh base. A light blue “N” logo appears on both sides of the shoe. Neon green “JFG” branding is printed on the lateral side of the heel and “Outside” and “Clothes” are embroidered in green script on the left and right shoe, respectively. The phrase “Made for Us” appears on the heel. Together, the colors on the shoe: green, brown, and blue, represent grass, dirt, and the sky—all elements of being outside on a warm summer’s day",
                           Size = 42,
                           CategoryId = 3,
                           DateCreated = DateTime.Now,
                           OriginalPrice = 2400000
                       },
                         new Product
                         {
                             Id = 11,
                             Name = "Vans UA Era Classic Sport",
                             Description = "Creating a pleasant feeling at first sight, Vans Classic Sport Era owns an extremely delicate color scheme, alternating between two gentle but equally youthful Drizzle & Ballad Blue colors to create a trendy look. personalities. The dynamic, flexible Era design is made entirely of high-quality, smooth and soft Textile fabric that promises to bring you the best wearing experience.",
                             Size = 42,
                             CategoryId = 5,
                             DateCreated = DateTime.Now,
                             OriginalPrice = 2210000
                         },
                        new Product
                        {
                            Id = 12,
                            Name = "Superturf Adventure SW x A GW8810",
                            Description = "The Sean Wotherspoon x adidas Superstar “SuperEarth - Black” is the follow-up release of the debut collaboration between the vintage apparel and footwear curator and adidas. Wotherspoon and adidas’s first “SuperEarth” collaboration took place in August 2010 with this “Black” colorway releasing in October 2021. Consistent with the theme of all of Wotherspoon’s sneaker collaborations, the Superstar SuperEarth is an all-vegan shoe made from recycled materials. The upper features a multicolor embroidered floral motif across either side. Metallic Gold “SuperEarth” and “adidas” branding are printed on the left and right light blue leather heel tabs, respectively. The cream rubber shell toe brings a classic Superstar look onto this modern colorway. Mismatched leather eyelet panels combine with unique “SuperEarth” inspired branding on the left and right tongue tags to form a progressive look",
                            Size = 42,
                            CategoryId = 2,
                            DateCreated = DateTime.Now,
                            OriginalPrice = 2500000
                        },
                         new Product
                         {
                             Id = 13,
                             Name = "Converse Chuck 70 Fuzzy Ambush ",
                             Description = "Chuck Taylor All Star II Festival with soft, high-elastic Knit knit fabric is the ideal choice for women who like to exercise. The design of the shoe body with eye-catching patterns creates a prominent highlight for the product line. Soft Lunarlon shoe insole provides comfort as well as safety for the wearer despite long-time operation.",
                             Size = 42,
                             CategoryId = 4,
                             DateCreated = DateTime.Now,
                             OriginalPrice = 1950000
                         },
                          new Product
                          {
                              Id = 14,
                              Name = "Fragment x Sacai x Nike LDWaffle Blackened Blue",
                              Description = "The Fragment x Sacai x Nike LDWaffle “Blackened Blue” is a yet another chapter in the three-way collaboration between Hiroshi Fujiwara and Chitose Abe’s clothing brands and Nike on the hybrid shoe. The “Blackened Blue” is one of multiple colorways of the fusion shoe that combines elements of the Nike LDV and Waffle Racer released by Fragment, Sacai, and Nike in 2021. Black mesh can be found on the base while Blue Void hairy suede appears on the overlays on the forefoot, eyelets, and heel. Two white leather Swooshes are layered over one another on either side. Dual Sacai and Nike branding is printed on the white leather heel tab. Two sets of navy blue laces are placed on top of the stacked tongues. The aforementioned design elements are taken from the original Sacai x Nike LDWaffle. Text reading “The Classic / Fragment : sacai” is printed on the white foam midsole",
                              Size = 42,
                              CategoryId = 1,
                              DateCreated = DateTime.Now,
                              OriginalPrice = 2110000
                          },
                           new Product
                           {
                               Id = 15,
                               Name = "HS1 S Tarther Blast 1201A190 300",
                               Description = "Asics Lite Overlab Neon is for active and on-the-go young people, made from a combination of two high-quality waterproof polyester and ballistic mesh fabrics. In addition, it comes with an outsole that uses advanced Lite - Tech technology to help reduce the weight of the shoes significantly. Vibrant neon colors along with brand details give the design a striking trendy look, with a trendy look and set apart from the crowd.",
                               Size = 40,
                               CategoryId = 6,
                               DateCreated = DateTime.Now,
                               OriginalPrice = 2350000
                           },
                            new Product
                            {
                                Id = 16,
                                Name = "Adidas Originals Tokio Solar HM",
                                Description = "The HUMAN MADE x adidas Originals Tokio Solar HM adds vibrant green color to a new silhouette brought to you by visionary creative and archivist NIGO. The collaborative adidas shoe draws inspiration from NIGO’s personal archive and adidas’s vintage sporting heritage. Taking design elements from the Tokio trainer that was developed for the 1964 Tokyo Olympics, the Tokio Solar HM is made of a Primeknit upper with suede panels and leather Three Stripes. An 'X' detail, made out of the same leather as the Three Stripes, appears on the mid panel and heel.",
                                Size = 41,
                                CategoryId = 2,
                                DateCreated = DateTime.Now,
                                OriginalPrice = 2200000
                            },
                             new Product
                             {
                                 Id = 17,
                                 Name = "Superturf Adventure SW x A GW8810",
                                 Description = "The Sean Wotherspoon x adidas Superstar “SuperEarth - Black” is the follow-up release of the debut collaboration between the vintage apparel and footwear curator and adidas. Wotherspoon and adidas’s first “SuperEarth” collaboration took place in August 2010 with this “Black” colorway releasing in October 2021. Consistent with the theme of all of Wotherspoon’s sneaker collaborations, the Superstar SuperEarth is an all-vegan shoe made from recycled materials. The upper features a multicolor embroidered floral motif across either side. Metallic Gold “SuperEarth” and “adidas” branding are printed on the left and right light blue leather heel tabs, respectively. The cream rubber shell toe brings a classic Superstar look onto this modern colorway. Mismatched leather eyelet panels combine with unique “SuperEarth” inspired branding on the left and right tongue tags to form a progressive look",
                                 Size = 42,
                                 CategoryId = 3,
                                 DateCreated = DateTime.Now,
                                 OriginalPrice = 2000000
                             }
             );
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    Id = 1,
                    ProductId = 1,
                    FileName = "1.1.jpg",
                    Caption = "Cake Image",
                    DateCreated = DateTime.Now,
                },
                 new ProductImage
                 {
                     Id = 2,
                     ProductId = 1,
                     FileName = "1.2.jpg",
                     Caption = "Cake Image",
                     DateCreated = DateTime.Now,
                 },
                  new ProductImage
                  {
                      Id = 3,
                      ProductId = 1,
                      FileName = "1.3.jpg",
                      Caption = "Cake Image",
                      DateCreated = DateTime.Now,
                  },
                   new ProductImage
                   {
                       Id = 4,
                       ProductId = 1,
                       FileName = "1.4.jpg",
                       Caption = "Cake Image",
                       DateCreated = DateTime.Now,
                   },
                    new ProductImage
                    {
                        Id = 5,
                        ProductId = 2,
                        FileName = "2.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 6,
                        ProductId = 2,
                        FileName = "2.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 7,
                        ProductId = 2,
                        FileName = "2.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 8,
                        ProductId = 2,
                        FileName = "2.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 9,
                        ProductId = 3,
                        FileName = "3.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 10,
                        ProductId = 3,
                        FileName = "3.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 11,
                        ProductId = 3,
                        FileName = "3.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 12,
                        ProductId = 3,
                        FileName = "3.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 13,
                        ProductId = 4,
                        FileName = "4.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 14,
                        ProductId = 4,
                        FileName = "4.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 15,
                        ProductId = 4,
                        FileName = "4.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 16,
                        ProductId = 4,
                        FileName = "4.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 17,
                        ProductId = 5,
                        FileName = "5.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 18,
                        ProductId = 5,
                        FileName = "5.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 19,
                        ProductId = 5,
                        FileName = "5.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 20,
                        ProductId = 5,
                        FileName = "5.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 21,
                        ProductId = 6,
                        FileName = "6.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 22,
                        ProductId = 6,
                        FileName = "6.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 23,
                        ProductId = 6,
                        FileName = "6.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 24,
                        ProductId = 6,
                        FileName = "6.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 25,
                        ProductId = 7,
                        FileName = "7.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 26,
                        ProductId = 7,
                        FileName = "7.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 27,
                        ProductId = 7,
                        FileName = "7.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 28,
                        ProductId = 7,
                        FileName = "7.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 29,
                        ProductId = 8,
                        FileName = "8.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 30,
                        ProductId = 8,
                        FileName = "8.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 31,
                        ProductId = 8,
                        FileName = "8.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 32,
                        ProductId = 8,
                        FileName = "8.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 33,
                        ProductId = 9,
                        FileName = "9.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 34,
                        ProductId = 9,
                        FileName = "9.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 35,
                        ProductId = 9,
                        FileName = "9.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 36,
                        ProductId = 9,
                        FileName = "9.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 37,
                        ProductId = 10,
                        FileName = "10.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 38,
                        ProductId = 10,
                        FileName = "10.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 39,
                        ProductId = 10,
                        FileName = "10.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 40,
                        ProductId = 10,
                        FileName = "10.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 41,
                        ProductId = 11,
                        FileName = "11.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 42,
                        ProductId = 11,
                        FileName = "11.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 43,
                        ProductId = 11,
                        FileName = "11.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 44,
                        ProductId = 11,
                        FileName = "11.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 45,
                        ProductId = 12,
                        FileName = "12.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 46,
                        ProductId = 12,
                        FileName = "12.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 47,
                        ProductId = 12,
                        FileName = "12.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 48,
                        ProductId = 12,
                        FileName = "12.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 49,
                        ProductId = 13,
                        FileName = "13.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 50,
                        ProductId = 13,
                        FileName = "13.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 51,
                        ProductId = 13,
                        FileName = "13.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 52,
                        ProductId = 13,
                        FileName = "13.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 53,
                        ProductId = 14,
                        FileName = "14.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 54,
                        ProductId = 14,
                        FileName = "14.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 55,
                        ProductId = 14,
                        FileName = "14.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 56,
                        ProductId = 14,
                        FileName = "14.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 57,
                        ProductId = 15,
                        FileName = "15.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 58,
                        ProductId = 15,
                        FileName = "15.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    },
                    new ProductImage
                    {
                        Id = 59,
                        ProductId = 15,
                        FileName = "15.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    },
                    new ProductImage
                    {
                        Id = 60,
                        ProductId = 15,
                        FileName = "15.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 61,
                        ProductId = 16,
                        FileName = "16.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 62,
                        ProductId = 16,
                        FileName = "16.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 63,
                        ProductId = 16,
                        FileName = "16.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 64,
                        ProductId = 16,
                        FileName = "16.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 65,
                        ProductId = 17,
                        FileName = "17.1.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 66,
                        ProductId = 17,
                        FileName = "17.2.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }, new ProductImage
                    {
                        Id = 67,
                        ProductId = 17,
                        FileName = "17.3.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    },
                    new ProductImage
                    {
                        Id = 68,
                        ProductId = 17,
                        FileName = "17.4.jpg",
                        Caption = "Cake Image",
                        DateCreated = DateTime.Now,
                    }
             );
            //create guids for user and admin
            var adminRoleId = new Guid("9E87B492-5343-4272-9A34-FA5DE7CFFB22");
            var userRoleId = new Guid("8F7579EE-4AF9-4B71-9ADA-7F792F76DC31");
            var adminId = new Guid("372EA575-2536-4076-9BAB-3E3138DE495F");
            var userId = new Guid("8A820ADB-93D7-4C6F-9404-BDBFC14419F4");
            var userId2 = new Guid("51B4B238-4AE0-4E46-A3F4-E0ACF7666B15");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                },
                  new AppRole
                  {
                      Id = userRoleId,
                      Name = "customer",
                      NormalizedName = "customer",
                      Description = "Customer role"
                  }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "huy@gmail.com",
                    NormalizedEmail = "huy@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    SecurityStamp = string.Empty,
                    Name = "Lam Nhut Huy",
                    DoB = new DateTime(2000, 07, 23),
                    Address = "Can Tho"
                },
                new AppUser
                {
                    Id = userId,
                    UserName = "nguyenvanhoang",
                    NormalizedUserName = "user",
                    Email = "hoang@gmail.com",
                    NormalizedEmail = "hoang@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    SecurityStamp = string.Empty,
                    Name = "Nguyen Van Hoang",
                    DoB = new DateTime(1999, 09, 13),
                    Address = "131, phường Cầu Kho, quận 1, TP.HCM"
                },
                new AppUser
                {
                    Id = userId2,
                    UserName = "myduyentran",
                    NormalizedUserName = "user",
                    Email = "duyen@gmail.com",
                    NormalizedEmail = "duyen@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    SecurityStamp = string.Empty,
                    Name = "Tran Thi My Duyen",
                    DoB = new DateTime(2001, 03, 17),
                    Address = "Kiên Giang"
                }
            );
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
              new IdentityUserRole<Guid>
              {
                  RoleId = adminRoleId,
                  UserId = adminId,
              },
              new IdentityUserRole<Guid>
              {
                  RoleId = userRoleId,
                  UserId = userId,
              },
              new IdentityUserRole<Guid>
              {
                  RoleId = userRoleId,
                  UserId = userId2,
              });
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = new Guid("8A820ADB-93D7-4C6F-9404-BDBFC14419F4"),
                    DateCreated = new DateTime(2022, 1, 27, 9, 30, 0),
                    DeliveryDate = new DateTime(2022, 1, 30, 9, 30, 0),
                    Status = Enums.Status.Pending,
                    Total = 2200000

                },
                 new Order
                 {
                     Id = 2,
                     UserId = new Guid("8A820ADB-93D7-4C6F-9404-BDBFC14419F4"),
                     DateCreated = new DateTime(2022, 2, 2, 10, 25, 0),
                     DeliveryDate = new DateTime(2022, 2, 5, 10, 25, 0),
                     Status = Enums.Status.Shipping,
                     Total = 5000000
                 },
                  new Order
                  {
                      Id = 3,
                      UserId = new Guid("51B4B238-4AE0-4E46-A3F4-E0ACF7666B15"),
                      DateCreated = new DateTime(2022, 1, 28, 15, 30, 0),
                      DeliveryDate = new DateTime(2022, 2, 1, 15, 30, 0),
                      Status = Enums.Status.Completed,
                      Total = 1600000

                  },
                    new Order
                    {
                        Id = 4,
                        UserId = new Guid("51B4B238-4AE0-4E46-A3F4-E0ACF7666B15"),
                        DateCreated = new DateTime(2022, 2, 3, 7, 0, 0),
                        DeliveryDate = new DateTime(2022, 2, 6, 7, 0, 0),
                        Status = Enums.Status.Confirmed,
                        Total = 1700000
                    }
             );
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    OrderId = 1,
                    ProductId = 16,
                    Amount = 1
                },
                 new OrderDetail
                 {
                     OrderId = 2,
                     ProductId = 1,
                     Amount = 1
                 },
                 new OrderDetail
                 {
                     OrderId = 3,
                     ProductId = 12,
                     Amount = 1
                 },
                 new OrderDetail
                 {
                     OrderId = 2,
                     ProductId = 5,
                     Amount = 1
                 },
                 new OrderDetail
                 {
                     OrderId = 4,
                     ProductId = 8,
                     Amount = 1
                 }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    ProductId = 1,
                    UserId = new Guid("8A820ADB-93D7-4C6F-9404-BDBFC14419F4"),
                    content = "Giày đẹp",
                    DateCreated = DateTime.Now,

                },
                 new Comment
                 {
                     Id = 2,
                     ProductId = 2,
                     UserId = new Guid("8A820ADB-93D7-4C6F-9404-BDBFC14419F4"),
                     content = "Giày mang hơi rộng.",
                     DateCreated = DateTime.Now,

                 },
                  new Comment
                  {
                      Id = 3,
                      ProductId = 1,
                      UserId = new Guid("51B4B238-4AE0-4E46-A3F4-E0ACF7666B15"),
                      content = "Giày mang êm",
                      DateCreated = DateTime.Now,

                  },
                 new Comment
                 {
                     Id = 4,
                     ProductId = 2,
                     UserId = new Guid("51B4B238-4AE0-4E46-A3F4-E0ACF7666B15"),
                     content = "Giao hàng hơi chậm",
                     DateCreated = DateTime.Now,

                 }
             );
        }
    }
}
