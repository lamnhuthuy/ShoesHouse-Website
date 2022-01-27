using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoesHouse.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9e87b492-5343-4272-9a34-fa5de7cffb22"), "8435f3fa-828b-4b0a-aa81-0a2084343fac", "Administrator role", "admin", "admin" },
                    { new Guid("8f7579ee-4af9-4b71-9ada-7f792f76dc31"), "1beaf212-511e-4289-8f7f-eb23e7b4f040", "Customer role", "customer", "customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DoB", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("372ea575-2536-4076-9bab-3e3138de495f"), 0, "Can Tho", "c1092afc-f17c-4d88-8c0f-d958f20d2591", new DateTime(2000, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy@gmail.com", true, false, null, "Lam Nhut Huy", "huy@gmail.com", "admin", "AQAAAAEAACcQAAAAECxAACcJV8b2uDTkgHoatkfHXQxtKhngmb2rJrj1RNZUfS9ySa+oiVqbqohqizG1zg==", null, false, "", false, "admin" },
                    { new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4"), 0, "131, phường Cầu Kho, quận 1, TP.HCM", "d5f403c5-fe3d-421a-b63d-845b7c3ea6bc", new DateTime(1999, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoang@gmail.com", true, false, null, "Nguyen Van Hoang", "hoang@gmail.com", "user", "AQAAAAEAACcQAAAAELQ7w0Hdo322ETn48mwOKgQNPR03mIixIoNbbzxR7hdyozVs+CisUrxcBydryIKOQw==", null, false, "", false, "nguyenvanhoang" },
                    { new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15"), 0, "Kiên Giang", "bd77fc9a-b6d5-444e-b19f-b8e30ebde25e", new DateTime(2001, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "duyen@gmail.com", true, false, null, "Tran Thi My Duyen", "duyen@gmail.com", "user", "AQAAAAEAACcQAAAAEMDniwr2grAmabD2xpYDQ1NH7T+b/b3EkMyfNQggH/gpdfK8hTVTLfJxzrBGO7qIqw==", null, false, "", false, "myduyentran" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9e87b492-5343-4272-9a34-fa5de7cffb22"), new Guid("372ea575-2536-4076-9bab-3e3138de495f") },
                    { new Guid("8f7579ee-4af9-4b71-9ada-7f792f76dc31"), new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4") },
                    { new Guid("8f7579ee-4af9-4b71-9ada-7f792f76dc31"), new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All the must-have releases from Nike, with everything from icons like the Nike Air Force 1 and Nike Air Max line, to Nike SB, to the latest in-demand collaborations from the famous footwear brand known and loved across the globe.", "Nike" },
                    { 2, "The \"Brand with the 3 Stripes\" is a legend, birthing classics from the Stan Smith to the Superstar before reinventing itself with NMD, Ultra Boost, and its Yeezy collection.", "Adidas" },
                    { 3, "Known for premium quality and ultimate comfort, New Balance is one of the world’s premier athletic footwear brands. Find a full range of the New England-based brand’s retro runners, modern hits, and coveted collaborations here.", "New Balance" },
                    { 4, "More than a century of established excellence.", "Converse" },
                    { 5, "Live \"Off The Wall\" with Vans Old Skools, Vans Slip-Ons, and more.", "Vans" },
                    { 6, "Retro classics like the Gel-Lyte III and much more.", "Asics" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateDeleted", "DateModified", "DeliveryDate", "Status", "Total", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2022, 1, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, 2200000m, new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4") },
                    { 2, null, null, new DateTime(2022, 2, 5, 10, 25, 0, 0, DateTimeKind.Unspecified), 2, 5000000m, new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4") },
                    { 3, null, null, new DateTime(2022, 2, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 4, 1600000m, new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15") },
                    { 4, null, null, new DateTime(2022, 2, 6, 7, 0, 0, 0, DateTimeKind.Unspecified), 1, 1700000m, new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateDeleted", "DateModified", "Description", "Name", "Note", "OriginalPrice", "Price", "Size" },
                values: new object[,]
                {
                    { 6, 6, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2708), null, null, "The Concepts x ASICS GEL-Lyte III \"Otoro\" is a collaborative sneaker that exemplifies storytelling at its finest. Symbolic of the Bluefin Tuna and its highly acclaimed belly fat called “Otoro,” this special-edition shoe updates the Gel-Lyte III silhouette with premium pigskin suede in various shades of pink—which is a nod to the beautiful color of the fish. Reflective accents represent sushi tools used to eat the delectable dish. To commemorate the collaboration, a Concepts logo is debossed into the lateral heel area", " Asics Concepts - Otoro", null, 2000000m, null, 42 },
                    { 11, 5, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2718), null, null, "Creating a pleasant feeling at first sight, Vans Classic Sport Era owns an extremely delicate color scheme, alternating between two gentle but equally youthful Drizzle & Ballad Blue colors to create a trendy look. personalities. The dynamic, flexible Era design is made entirely of high-quality, smooth and soft Textile fabric that promises to bring you the best wearing experience.", "Vans UA Era Classic Sport", null, 2210000m, null, 42 },
                    { 5, 5, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2706), null, null, "The Notre x Vans OG Old Skool LX \"White\" is one of several colorways of the classic lifestyle shoe created by the Chicago clothing and sneaker boutique and Vans for Fall 2020. The Vans OG Old Skool LX receives several updates in design from its venerable Old Skool relative, including a new premium suede construction, a padded leather collar, and cream, vulcanized midsole. Here, on the Notre-designed “White” colorway, hairy cream suede can be found on the entire upper. Notre places its signature handshake logo on either side in place of the Old Skool’s signature wavy detailing. A black “Vans” branded license plate resides on the heel of the cream sole", "Vans attitude Notre - White", null, 1600000m, null, 42 },
                    { 13, 4, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2722), null, null, "Chuck Taylor All Star II Festival with soft, high-elastic Knit knit fabric is the ideal choice for women who like to exercise. The design of the shoe body with eye-catching patterns creates a prominent highlight for the product line. Soft Lunarlon shoe insole provides comfort as well as safety for the wearer despite long-time operation.", "Converse Chuck 70 Fuzzy Ambush ", null, 1950000m, null, 42 },
                    { 8, 4, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2712), null, null, "Palladium Pampa Lite Overlab Neon for active and on-the-go young people, made from a combination of two high-quality waterproof polyester and ballistic mesh fabrics. In addition, it comes with an outsole that uses advanced Lite - Tech technology to help reduce the weight of the shoes significantly. Vibrant neon colors along with brand details give the design a striking trendy look, with a trendy look and setting it apart from the crowd.", "Palladium Pampa Lite Overlab Neon", null, 1700000m, null, 42 },
                    { 4, 4, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2703), null, null, "The Converse Run Star Hike Hi gives the classic Chuck Taylor design an edgy twist with its chunky platform style and jagged sole. The upper remains untouched from its original style with the black canvas construction, white rubber toe cap, and Chuck Taylor emblem. Meanwhile, the bottom introduces a new look with a two-tone outsole and thick platform that remains true to its iconic roots. This iteration lends a fashion-forward appeal and modern vibe.", "Run Star Hike", null, 1300000m, null, 42 },
                    { 17, 3, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2729), null, null, "The Sean Wotherspoon x adidas Superstar “SuperEarth - Black” is the follow-up release of the debut collaboration between the vintage apparel and footwear curator and adidas. Wotherspoon and adidas’s first “SuperEarth” collaboration took place in August 2010 with this “Black” colorway releasing in October 2021. Consistent with the theme of all of Wotherspoon’s sneaker collaborations, the Superstar SuperEarth is an all-vegan shoe made from recycled materials. The upper features a multicolor embroidered floral motif across either side. Metallic Gold “SuperEarth” and “adidas” branding are printed on the left and right light blue leather heel tabs, respectively. The cream rubber shell toe brings a classic Superstar look onto this modern colorway. Mismatched leather eyelet panels combine with unique “SuperEarth” inspired branding on the left and right tongue tags to form a progressive look", "Superturf Adventure SW x A GW8810", null, 2000000m, null, 42 },
                    { 3, 3, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2700), null, null, "The Salehe Bembury x New Balance 2002R is the second highly coveted collaboration by the footwear and fashion designer and New Balance. As its nickname implies, the colorway is inspired by water, the source of life for us all, and is colored accordingly with a refreshing aqua blue hairy suede upper. Premium brown leather detailing is found on the tongue and at the ankle, while the light tan mesh base adds plenty of breathability. Shearling N logos in green add another earthy vibe. New Balance's NERGY foam midsole provides a light and cushioned feel all day long", "Salehe Bembury - Water Be The Guide", null, 2400000m, null, 42 },
                    { 7, 6, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2710), null, null, "These Asics Gel Excite 7 Men's Running Shoes have been crafted with an AmpliFoam midsole which delivers a flexible and tactile ride as well as offering exceptional cushioning with every stride. The breathable mesh fabric upper allows your feet to remain cool and comfortable throughout your run, whilst the GEL technology helps absorb shock and adds further cushioning for a comfortable running experience.", "Asics Gel Excite 7 Men's Running", null, 1900000m, null, 42 },
                    { 16, 2, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2728), null, null, "The HUMAN MADE x adidas Originals Tokio Solar HM adds vibrant green color to a new silhouette brought to you by visionary creative and archivist NIGO. The collaborative adidas shoe draws inspiration from NIGO’s personal archive and adidas’s vintage sporting heritage. Taking design elements from the Tokio trainer that was developed for the 1964 Tokyo Olympics, the Tokio Solar HM is made of a Primeknit upper with suede panels and leather Three Stripes. An 'X' detail, made out of the same leather as the Three Stripes, appears on the mid panel and heel.", "Adidas Originals Tokio Solar HM", null, 2200000m, null, 41 },
                    { 12, 2, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2720), null, null, "The Sean Wotherspoon x adidas Superstar “SuperEarth - Black” is the follow-up release of the debut collaboration between the vintage apparel and footwear curator and adidas. Wotherspoon and adidas’s first “SuperEarth” collaboration took place in August 2010 with this “Black” colorway releasing in October 2021. Consistent with the theme of all of Wotherspoon’s sneaker collaborations, the Superstar SuperEarth is an all-vegan shoe made from recycled materials. The upper features a multicolor embroidered floral motif across either side. Metallic Gold “SuperEarth” and “adidas” branding are printed on the left and right light blue leather heel tabs, respectively. The cream rubber shell toe brings a classic Superstar look onto this modern colorway. Mismatched leather eyelet panels combine with unique “SuperEarth” inspired branding on the left and right tongue tags to form a progressive look", "Superturf Adventure SW x A GW8810", null, 2500000m, null, 42 },
                    { 2, 2, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2676), null, null, "The BBC x Pharrell x adidas NMD Hu “Astronaut Blue” is a November 2021 collaboration between the Virginia native, his streetwear brand, and adidas on the former’s popular signature shoe. This three-way collaboration between Billionaire Boys Club, Pharrell, and adidas brings a neutral-colored look to the NMD Hu. The “Astronaut Blue” features BBC’s signature “Astronaut” branding on its design, specifically on the top of both the left and right shoe. The upper is constructed from a Halo Blue-colored sweater-like material, the same ribbed knit upper that is also found on the adidas NMD Hu’s “Cream” colorway. The shoe is constructed in a slip-on-like style with wraparound laces incorporated into the translucent midfoot cage found on either side. BBC’s “Astronaut” logo appears on the back of the left shoe while adidas’s Trefoil logo is found on the back of the right shoe. Underfoot, a responsive Boost midsole completes the look.", "Pharrell - Billionaire Boys Club - Astronaut Blue ", null, 2100000m, null, 41 },
                    { 14, 1, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2724), null, null, "The Fragment x Sacai x Nike LDWaffle “Blackened Blue” is a yet another chapter in the three-way collaboration between Hiroshi Fujiwara and Chitose Abe’s clothing brands and Nike on the hybrid shoe. The “Blackened Blue” is one of multiple colorways of the fusion shoe that combines elements of the Nike LDV and Waffle Racer released by Fragment, Sacai, and Nike in 2021. Black mesh can be found on the base while Blue Void hairy suede appears on the overlays on the forefoot, eyelets, and heel. Two white leather Swooshes are layered over one another on either side. Dual Sacai and Nike branding is printed on the white leather heel tab. Two sets of navy blue laces are placed on top of the stacked tongues. The aforementioned design elements are taken from the original Sacai x Nike LDWaffle. Text reading “The Classic / Fragment : sacai” is printed on the white foam midsole", "Fragment x Sacai x Nike LDWaffle Blackened Blue", null, 2110000m, null, 42 },
                    { 9, 1, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2714), null, null, "White leather/rubber Air Force 1 '07 Craft sneakers from NIKE featuring round toe, flat rubber sole, front lace - up fastening, branded insole, signature Swoosh logo detail and perforated design.These styles are supplied by a premium sneaker marketplace.Stocking only the most sought - after footwear, they source and curate some of the most hard to find sneakers from around the world", "Nike Air Max 98 South Beach", null, 1750000m, null, 42 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateDeleted", "DateModified", "Description", "Name", "Note", "OriginalPrice", "Price", "Size", "Stock" },
                values: new object[] { 1, 1, new DateTime(2022, 1, 27, 22, 51, 11, 827, DateTimeKind.Local).AddTicks(680), null, null, "The Nike Dunk High “Dark Curry” puts an appealing lifestyle look on the timeless high-top shoe. The “Dark Curry” was released in March 2021 and exemplifies Nike’s efforts of expanding the Dunk’s footprint in sneakers. A year earlier, in 2020, the Nike Dunk re-emerged from relative obscurity to once again capture the attention of sneaker collectors due to an impressive amount of limited edition collaborations and returning retro colorways.As for the design of the “Dark Curry,” hairy orange-brown suede overlays on the model’s forefoot, eyelets, collar, and heel contrast the black brushed suede base. A darker shade of brown suede can be found on the Swoosh branding on either side and on the small pull tab on the heel. Nike layers brown laces over the black mesh tongue and adds a midsole for a timeless look. Underfoot, a tan outsole finishes off the look of the “Dark Curry.” ", "Nike Dunk High “Dark Curry” ", null, 2500000m, null, 42, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateDeleted", "DateModified", "Description", "Name", "Note", "OriginalPrice", "Price", "Size" },
                values: new object[,]
                {
                    { 10, 3, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2716), null, null, "The Joe Freshgoods x New Balance 990V3 “Outside Clothes” is the much anticipated follow up to the Chicago native’s heralded collaboration with the Boston footwear company on the 992 “No Emotions Are Emotions” from 2020. The “Outside Clothes” colorway of the classic 990V3 was released in limited quantities exclusively in Joe Freshgoods’ hometown of Chicago at Garfield Park where he grew up. Accompanied by an advertisement directed by Mike Carson and scored by Alchemist that explains the origins of the design, the multicolor look features beige suede overlays atop an aqua mesh base. A light blue “N” logo appears on both sides of the shoe. Neon green “JFG” branding is printed on the lateral side of the heel and “Outside” and “Clothes” are embroidered in green script on the left and right shoe, respectively. The phrase “Made for Us” appears on the heel. Together, the colors on the shoe: green, brown, and blue, represent grass, dirt, and the sky—all elements of being outside on a warm summer’s day", "Joe Freshgoods x New Balance 990V3 Outside Clothes", null, 2400000m, null, 42 },
                    { 15, 6, new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(2726), null, null, "Asics Lite Overlab Neon is for active and on-the-go young people, made from a combination of two high-quality waterproof polyester and ballistic mesh fabrics. In addition, it comes with an outsole that uses advanced Lite - Tech technology to help reduce the weight of the shoes significantly. Vibrant neon colors along with brand details give the design a striking trendy look, with a trendy look and set apart from the crowd.", "HS1 S Tarther Blast 1201A190 300", null, 2350000m, null, 40 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateModified", "ProductId", "UserId", "content" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 27, 22, 51, 11, 851, DateTimeKind.Local).AddTicks(420), null, null, 1, new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4"), "Giày đẹp" },
                    { 3, new DateTime(2022, 1, 27, 22, 51, 11, 851, DateTimeKind.Local).AddTicks(676), null, null, 1, new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15"), "Giày mang êm" },
                    { 4, new DateTime(2022, 1, 27, 22, 51, 11, 851, DateTimeKind.Local).AddTicks(678), null, null, 2, new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15"), "Giao hàng hơi chậm" },
                    { 2, new DateTime(2022, 1, 27, 22, 51, 11, 851, DateTimeKind.Local).AddTicks(672), null, null, 2, new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4"), "Giày mang hơi rộng." }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Amount" },
                values: new object[,]
                {
                    { 2, 5, 1 },
                    { 1, 16, 1 },
                    { 4, 8, 1 },
                    { 3, 12, 1 },
                    { 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Caption", "DateCreated", "FileName", "ProductId" },
                values: new object[,]
                {
                    { 29, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4796), "8.1.jpg", 8 },
                    { 30, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4798), "8.2.jpg", 8 },
                    { 17, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4777), "5.1.jpg", 5 },
                    { 32, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4801), "8.4.jpg", 8 },
                    { 49, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4838), "13.1.jpg", 13 },
                    { 50, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4840), "13.2.jpg", 13 },
                    { 51, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4842), "13.3.jpg", 13 },
                    { 15, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4774), "4.3.jpg", 4 },
                    { 14, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4772), "4.2.jpg", 4 },
                    { 13, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4771), "4.1.jpg", 4 },
                    { 52, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4843), "13.4.jpg", 13 },
                    { 16, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4775), "4.4.jpg", 4 },
                    { 31, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4800), "8.3.jpg", 8 },
                    { 19, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4780), "5.3.jpg", 5 },
                    { 68, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4869), "17.4.jpg", 17 },
                    { 58, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4853), "15.2.jpg", 15 },
                    { 57, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4852), "15.1.jpg", 15 },
                    { 28, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4795), "7.4.jpg", 7 },
                    { 27, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4793), "7.3.jpg", 7 },
                    { 26, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4791), "7.2.jpg", 7 },
                    { 25, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4790), "7.1.jpg", 7 },
                    { 24, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4788), "6.4.jpg", 6 },
                    { 23, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4787), "6.3.jpg", 6 },
                    { 22, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4785), "6.2.jpg", 6 },
                    { 21, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4783), "6.1.jpg", 6 },
                    { 44, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4821), "11.4.jpg", 11 },
                    { 43, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4819), "11.3.jpg", 11 },
                    { 42, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4818), "11.2.jpg", 11 },
                    { 41, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4816), "11.1.jpg", 11 },
                    { 20, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4782), "5.4.jpg", 5 },
                    { 18, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4779), "5.2.jpg", 5 },
                    { 67, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4868), "17.3.jpg", 17 },
                    { 40, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4814), "10.4.jpg", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Caption", "DateCreated", "FileName", "ProductId" },
                values: new object[,]
                {
                    { 65, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4864), "17.1.jpg", 17 },
                    { 6, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4758), "2.2.jpg", 2 },
                    { 5, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4756), "2.1.jpg", 2 },
                    { 56, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4850), "14.4.jpg", 14 },
                    { 55, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4848), "14.3.jpg", 14 },
                    { 54, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4847), "14.2.jpg", 14 },
                    { 53, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4845), "14.1.jpg", 14 },
                    { 7, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4760), "2.3.jpg", 2 },
                    { 36, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4808), "9.4.jpg", 9 },
                    { 34, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4805), "9.2.jpg", 9 },
                    { 33, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4803), "9.1.jpg", 9 },
                    { 4, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4755), "1.4.jpg", 1 },
                    { 3, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4753), "1.3.jpg", 1 },
                    { 2, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4750), "1.2.jpg", 1 },
                    { 1, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4501), "1.1.jpg", 1 },
                    { 35, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4806), "9.3.jpg", 9 },
                    { 66, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4866), "17.2.jpg", 17 },
                    { 8, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4761), "2.4.jpg", 2 },
                    { 46, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4824), "12.2.jpg", 12 },
                    { 59, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4855), "15.3.jpg", 15 },
                    { 39, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4813), "10.3.jpg", 10 },
                    { 38, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4811), "10.2.jpg", 10 },
                    { 37, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4809), "10.1.jpg", 10 },
                    { 12, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4769), "3.4.jpg", 3 },
                    { 11, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4767), "3.3.jpg", 3 },
                    { 45, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4822), "12.1.jpg", 12 },
                    { 10, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4766), "3.2.jpg", 3 },
                    { 64, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4863), "16.4.jpg", 16 },
                    { 63, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4861), "16.3.jpg", 16 },
                    { 62, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4860), "16.2.jpg", 16 },
                    { 61, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4858), "16.1.jpg", 16 },
                    { 48, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4837), "12.4.jpg", 12 },
                    { 47, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4826), "12.3.jpg", 12 },
                    { 9, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4764), "3.1.jpg", 3 },
                    { 60, "Cake Image", new DateTime(2022, 1, 27, 22, 51, 11, 829, DateTimeKind.Local).AddTicks(4856), "15.4.jpg", 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8f7579ee-4af9-4b71-9ada-7f792f76dc31"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("9e87b492-5343-4272-9a34-fa5de7cffb22"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("372ea575-2536-4076-9bab-3e3138de495f"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9e87b492-5343-4272-9a34-fa5de7cffb22"), new Guid("372ea575-2536-4076-9bab-3e3138de495f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8f7579ee-4af9-4b71-9ada-7f792f76dc31"), new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8f7579ee-4af9-4b71-9ada-7f792f76dc31"), new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4") });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("51b4b238-4ae0-4e46-a3f4-e0acf7666b15"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("8a820adb-93d7-4c6f-9404-bdbfc14419f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
