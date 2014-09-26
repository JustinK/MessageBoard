using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationsConfiguration:DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {

            
#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "Really interesting subject matter",
                    Body = "Seriously this is the coolest thing ever",
                    Created = DateTime.Now,
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "very interesting indeed!",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "eh, it's ok",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "mildly interesting...",
                            Created = DateTime.Now
                        }
                    }

                };
                context.Topics.Add(topic);
                var topic2 = new Topic()
                {
                    Title = "An additional topic that is very interesting",
                    Body = "This one is better than the last one",
                    Created = DateTime.Now,
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "this one is even better!",
                            Created = DateTime.Now
                        }
                    }

                };
                context.Topics.Add(topic2);
                context.SaveChanges();
            }
            
#endif
        }
    }
}
