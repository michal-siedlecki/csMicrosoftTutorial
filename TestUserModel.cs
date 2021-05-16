using System;


namespace BankApplication
{
    class TestUserModel
    {
        public bool testUserId()
        {
            User user1 = new User("name", "surname", "address street");
            User user2 = new User("name", "surname", "address street");
            return user1.getUid() != user2.getUid();
        }

        public void run()
        {
            var methods = this.GetType().GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine(item);
            }
            if (testUserId() == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{this.GetType().Name} tests run OK");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{this.GetType().Name} tests FAILED");
                Console.ResetColor();
            }
        }
    }
}
