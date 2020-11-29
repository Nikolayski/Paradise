using Data;
using Models;
using Models.Enums;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.SeedService
{
    public   class SeedService : ISeedService
    {
        private readonly ApplicationDbContext db;

        public SeedService(ApplicationDbContext db)
        {
            this.db = db;
        }

       public async Task AddProductsAsync()
        {
            var images = new List<Image>
            {
                {new Image
                {
                     ImageType = RoomType.Superior,
                      Url = "https://i.pinimg.com/originals/85/32/a4/8532a4e5ab98b5ae1a962f0a91248f6a.jpg",

                }},
                  {new Image
                {
                     ImageType = RoomType.Superior,
                      Url = "https://cdn-prod.travelfuse.ro/images/_top_ac0c68cec4ce49d4bd8cf8a974608ff1.jpg",

                }},
                  {new Image
                {
                     ImageType = RoomType.Luxury,
                      Url = "https://dridha.co/wp-content/uploads/2019/11/awesome-small-master-bedroom-guest-most-beautiful-bedrooms-photos-pacific-palisades-long-hotel-interior-design.jpeg",

                }},
                   {new Image
                {
                     ImageType = RoomType.Luxury,
                      Url = "https://cf.bstatic.com/images/hotel/max1024x768/153/153954149.jpg",

                }},
                   {new Image
                {
                     ImageType = RoomType.Family,
                      Url = "https://www.jet2holidays.com/HotelImages/Web/SKG_74164_Sani_Beach_Hotel_&_Spa_0516_22.jpg",

                }},
                    {new Image
                {
                     ImageType = RoomType.Family,
                      Url = "https://beetravel.bg/wp-content/uploads/2017/07/Sani-beach-hotel-spa-7.jpg",

                }},
                      {new Image
                {
                     ImageType = RoomType.Tripple,
                      Url = "https://cf.bstatic.com/images/hotel/max1024x768/118/118104436.jpg",

                }},
                        {new Image
                {
                     ImageType = RoomType.Tripple,
                      Url = "https://cdn3.enuygun.com/media/lib/1x400/uploads/image/lugga-boutique-beach-oda-35262955.jpg",

                }},
                        {new Image
                {
                     ImageType = RoomType.Double,
                      Url = "https://cdn3.enuygun.com/media/lib/1x400/uploads/image/lugga-boutique-beach-oda-35262955.jpg",

                }},
                        {new Image
                {
                     ImageType = RoomType.Double,
                      Url = "https://www.reflectionscoolangattabeach.com.au/wp-content/uploads/2020/05/3-bedroom-skyhome4-1.jpg",

                }},
                        {new Image
                {
                     ImageType = RoomType.Single,
                      Url = "https://cf.bstatic.com/images/hotel/max1024x768/206/206471360.jpg",

                }},
                        {new Image
                {
                     ImageType = RoomType.Single,
                      Url = "https://media-cdn.tripadvisor.com/media/photo-s/16/6e/6b/51/seaside-junior-suite.jpg",

                }},
                        {new Image
                {
                     Type = ImageType.Index,
                      Url = "https://cdn.cnn.com/cnnnext/dam/assets/160726132219-us-beautiful-hotels-4-four-seasons-maui1.jpg",
                       Description = "Hotel for the whole family, all year round.",

                }},
                        {new Image
                {
                     Type = ImageType.Index,
                      Url = "https://www.oyster.com/uploads/sites/35//2019/05/grounds-v17871157-1440.jpg",
                       Description = "It feels like staying in your own home.",

                }},
                        {new Image
                {
                     Type = ImageType.Index,
                      Url = "https://edge.media.datahc.com/HI241563984.jpg",
                       Description = "You will never forget this adventure.",


                }},
                         {new Image
                {
                     Type = ImageType.Index,
                      Url = "https://c4.wallpaperflare.com/wallpaper/670/742/573/hotel-resort-tropical-pier-wallpaper-preview.jpg",
                       Description = "This is the earth's paradise.",

                }},
                            {new Image
                {
                     Type = ImageType.Index,
                      Url = "https://www.oyster.com/uploads/sites/35/2019/05/pool-v18618300-1440.jpg",
                       Description = "Most satisfying place on earth.",

                }},



            };

            this.db.Images.AddRange(images);
            await this.db.SaveChangesAsync();

            var products = new List<Product>
            {
                //Italian

                {new Product
                {
                     Nationality = ProductCountry.Italian,
                Type = ProductType.Main,
                Description = "Variety of pizza in Italian cuisine that is topped with a combination of four kinds of cheese, usually melted together, with (rossa, red) or without (bianca, white) tomato sauce.",
                Name = "Quattro formaggi",
                Price = 19.99M,
                Image = "https://4.bp.blogspot.com/-3eqyckCU3LA/VUR-U0LOn8I/AAAAAAABprc/TwaLIZPGlTo/s280/3-romana%2Bcopia.jpg",
                } },

                 {new Product
                {
                     Nationality = ProductCountry.Italian,
                Type = ProductType.Main,
                Description = "style of pizza made with tomatoes and mozzarella cheese.",
                Name = "Pizza Neapolitana",
                Price = 12.99M,
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg/250px-Eq_it-na_pizza-margherita_sep2005_sml.jpg",
                } },

                     {new Product
                {
                     Nationality = ProductCountry.Italian,
                Type = ProductType.Main,
                Description = "Traditional type of pasta from the Emilia-Romagna and Marche regions of Italy. Individual pieces of tagliatelle are long, flat ribbons that are similar in shape to fettuccine and are typically about 6.5 to 10 mm (0.26 to 0.39 in) wide.",
                Name = "Tagliateli",
                Price = 11.50M,
                Image = "https://t4.ftcdn.net/jpg/02/78/04/19/240_F_278041917_9PIfrbQVCrVIsteXsefJct1Osg0DxrQw.jpg",
                } },

                           {new Product
                {
                      Nationality = ProductCountry.Italian,
                Type = ProductType.Main,
                Description = "Traditional type of pasta from the Emilia-Romagna and Marche regions of Italy. Individual pieces of tagliatelle are long, flat ribbons that are similar in shape to fettuccine and are typically about 6.5 to 10 mm (0.26 to 0.39 in) wide.",
                Name = "Pasta Carbonara",
                Price = 11.99M,
                Image = "https://cdn140.picsart.com/238247617060212.png?type=webp&to=min&r=240",
                } },


                {new Product
                {
                       Nationality = ProductCountry.Italian,
                Type = ProductType.Salad,
                Description = "Green salad of romaine lettuce and croutons dressed with lemon juice (or lime juice), olive oil, egg, Worcestershire sauce, anchovies, garlic, Dijon mustard, Parmesan cheese, and black pepper.",
                Name = "Caesar",
                Price = 9.99M,
                Image = "https://cdn.shopify.com/s/files/1/0279/4825/3266/products/CaesarSaladKit_280x.png?v=1586458626",
                } },

               {new Product
                {
                     Nationality = ProductCountry.Italian,
                Type = ProductType.Dessert,
                Description = "Sweet dessert consisting of one or more layers. The main, and thickest layer, consists of a mixture of soft, fresh cheese (typically cream cheese or ricotta), eggs, and sugar. If there is a bottom layer, it often consists of a crust or base made from crushed cookies.",
                Name = "Cheesecake",
                Price = 5.99M,
                Image = "https://i.pinimg.com/474x/8b/a0/b8/8ba0b87c92f3f8969a6b1f219b6600fa.jpg",
                } },


               //Bulgarian
              {new Product
                {
                    Nationality = ProductCountry.Bulgarian,
                Type = ProductType.Main,
                Description = "Moussaka is an eggplant and/or potato-based dish, often including ground meat, which is common in the Balkans and the Middle East, with many local and regional variations.",
                Name = "Musaka",
                Price = 11.99M,
                Image = "https://ik.imagekit.io/smdxc0e2g3/userscontent2-endpoint/images/ed9c0514-132f-43a5-96c0-75cede5df718/4fc97b083e0106bf42ebd9c1a9141aaa.jpg?tr=w-280,h-240,rt-0",
                } },

                 {new Product
                {
                     Nationality = ProductCountry.Bulgarian,
                Type = ProductType.Salad,
                Description = "Made from tomatoes, cucumbers, onion/scallions, raw or roasted peppers, sirene (white brine cheese), and parsley.",
                Name = "Shopska Salad",
                Price = 5.99M,
                Image = "https://3.bp.blogspot.com/_XBF_I0kquMU/Sppk1ts8_2I/AAAAAAAAAaM/yKZJACTQ-V8/s280/fbBulgaria+1137.2.jpg",
                } },

                    {new Product
                {
                      Nationality = ProductCountry.Bulgarian,
                Type = ProductType.Dessert,
                Description = "Custard dessert with a layer of clear caramel sauce, contrasted with crème brûlée which is custard with a hard caramel layer on top",
                Name = "Crème caramel ",
                Price = 5.99M,
                Image = "https://2.bp.blogspot.com/_2J0uuh6QUQk/SbV0WOgGTLI/AAAAAAAABhg/Vkemu0wIqWA/s280/P3091030s.jpg",
                } },


              //Indian

               {new Product
                {
                     Nationality = ProductCountry.Indian,
                Type = ProductType.Main,
                Description = "Chicken in a spiced tomato, butter and cream sauce. It originated in the Indian subcontinent.",
                Name = "Murg Makhani",
                Price = 10.99M,
                Image = "https://4.bp.blogspot.com/-zrkBhkmBjbw/Tn9-t7bgCxI/AAAAAAAAABU/UClqrBCcLqM/s280/lamb+vindaloo+empanadas.jpg",
                } },

                {new Product
                {
                    Nationality = ProductCountry.Indian,
                Type = ProductType.Main,
                Description = "Mixed rice dish with its origins among the Muslims of the Indian subcontinent.",
                Name = "Biryani",
                Price = 13.00M,
                Image = "https://content.jdmagicbox.com/comp/hyderabad/c1/040pxx40.xx40.160420150039.c3c1/catalogue/bahar-biryani-cafe-l-b-nagar-hyderabad-biryani-restaurants-tiidors7ww.jpg",
                } },

                 {new Product
                {
                      Nationality = ProductCountry.Indian,
                Type = ProductType.Dessert,
                Description = " milk-solid-based sweet from the Indian subcontinen.",
                Name = "Gulab Jamun",
                Price = 5.99M,
                Image = "https://t3.ftcdn.net/jpg/02/28/08/72/240_F_228087243_XIAF5UxbqSHNJHjCa5Ulf8GrOZuQBr2Y.jpg",
                } },

                      {new Product
                {
                       Nationality = ProductCountry.Indian,
                Type = ProductType.Salad,
                Description = "Fresh salad with apple, spinach, porridge, pepper and sweet sauce.",
                Name = "Spring Indian",
                Price = 4.99M,
                Image = "https://i.pinimg.com/originals/96/41/1f/96411fd2025ff6808852683e5170a005.jpg",
                } },



               //Traditional
                        {new Product
                {
                      Nationality = ProductCountry.Traditional,
                Type = ProductType.Dessert,
                Description = "Traditional Middle Eastern dessert made with shredded filo pastry,[3] or alternatively fine semolina dough, soaked in sweet, sugar-based syrup, and typically layered with cheese, or with other ingredients such as clotted cream or nuts, depending on the region.",
                Name = "Kadaiff",
                Price = 8.00M,
                Image = "https://t4.ftcdn.net/jpg/03/11/21/55/240_F_311215583_bMbBPQX1S7SYtAImVXiGT92pu5SLRgus.jpg",
                } },

              {new Product
                {
                      Nationality = ProductCountry.Traditional,
                Type = ProductType.Main,
                Description = "Burger for every taste.",
                Name = "Burger ",
                Price = 8.75M,
                Image = "https://3.bp.blogspot.com/_sABB4tAd_Q0/ShyVQqNWpgI/AAAAAAAAAh0/VQaG6owgT14/s280/100_0847.JPG",
                } },

               {new Product
                {
                    Nationality = ProductCountry.Traditional,
                Type = ProductType.Salad,
                Description = "Generally made with pieces of tomatoes, cucumbers, onion, feta cheese and olives and dressed with salt, pepper.",
                Name = "Greek Salad ",
                Price = 6.75M,
                Image = "https://cdn.shopify.com/s/files/1/0334/4908/2925/products/2_bc20dc35-4638-4f50-a65e-1463c494b7a3_300x300.png?v=1587313667",
                } },


              //Spanish
            {new Product
                {
                     Nationality = ProductCountry.Spanish,
                Type = ProductType.Salad,
                Description = "The refreshing summer salad is usually dressed with olive oil, and vinegar, and slices of bread are often used as an accompaniment that is soaked in it, while tuna and olives are often added in order to elevate the flavors.",
                Name = "Pipirrana",
                Price = 6.50M,
                Image = "https://1.bp.blogspot.com/-7ecq-j0H5Fc/XxBHCPa4B7I/AAAAAAAAV-k/qxPwJyYbxiEpIHQ92OwQqccVzat5G34nQCLcBGAsYHQ/s280/20200706_145128.jpg",
                } },

             {new Product
                {
                     Nationality = ProductCountry.Spanish,
                Type = ProductType.Main,
                Description = "Famous spanish rice dish originally from Valencia.",
                Name = "Paella",
                Price = 11.50M,
                Image = "https://i.pinimg.com/474x/44/76/77/44767762d2c76551193661bfed3d9f9a.jpg",
                } },

               {new Product
                {
                      Nationality = ProductCountry.Spanish,
                Type = ProductType.Dessert,
                Description = "Small shortbread sugar cookies.",
                Name = "Mantecados ",
                Price = 7.50M,
                Image = "https://orejon.es/wp-content/uploads/2015/07/mantecados-manchegos-280x240.jpg",
                } },

            };

            var rooms = new List<Room>
            {
                {
                    new Room
                        {
                             RoomType = RoomType.Single,
                             Adults = 1,
                             Image = "https://www.wanderluststorytellers.com/wp-content/uploads/2019/05/Devasom-Khao-Lak-Beach-Resort-Villas-Best-Hotels-in-Khao-Lak-Room.jpg",
                              Price = 100,
                              RoomCount= 20,
                              Description = "Description for Single Room.",

                        }
                },
                 {
                    new Room
                        {
                             RoomType = RoomType.Double,
                             Adults = 2,
                             Image = "https://may-hotel.gr/wp-content/uploads/2018/10/Bed-balcony-Triple-room-1-May-Beach-Hotel-Rethymno-Crete.jpg.jpg",
                              Price = 180,
                              RoomCount= 20,
                              Description = "Description for Double Room.",

                        }
                },
                 {
                    new Room
                        {
                             RoomType = RoomType.Tripple,
                             Adults = 3,
                             Image = "https://q-xx.bstatic.com/xdata/images/hotel/840x460/117919616.jpg?k=e5a5762f2cab35b3e3f5351ef449c499ba5ebe28c8e6e8fdf8de94f93efba5d0&o=",
                              Price = 240,
                              RoomCount= 15,
                              Description = "Description for Tripple Room.",

                        }
                },

                   {
                    new Room
                        {
                             RoomType = RoomType.Family,
                             Adults = 4,
                             Image = "https://www.sani-resort.com/uploads/assets/667x444/luxury-lounge-sani-greece-02.jpg",
                              Price = 280,
                              RoomCount= 10,
                              Description = "Description for Family Room.",

                        }
                },
                   {
                    new Room
                        {
                             RoomType = RoomType.Luxury,
                             Adults = 2,
                             Image = "https://cf.bstatic.com/images/hotel/max1024x768/153/153952717.jpg",
                              Price = 320,
                              RoomCount= 5,
                              Description = "Description for Luxury Room.",

                        }
                },
                   {
                    new Room
                        {
                             RoomType = RoomType.Superior,
                             Adults = 2,
                             Image = "https://www.hotels2see.com/sites/default/files/images/luxury-penthouse-majorca-hotel-boutique.jpg",
                              Price = 380,
                              RoomCount= 5,
                              Description = "Description for Superior Room.",

                        }
                },

            };
            foreach (var room in rooms)
            {
                foreach (var image in images)
                {
                    if (image.ImageType == room.RoomType)
                    {
                        room.RoomImages.Add(new RoomImages { ImageId = image.Id, RoomId = room.Id });
                    }
                }
            }

            await this.db.Products.AddRangeAsync(products);
            await this.db.Rooms.AddRangeAsync(rooms);
            await this.db.SaveChangesAsync();

        }

        public bool IsPopulate()
        {
            return this.db.Products.Any();
        }
    }
}
