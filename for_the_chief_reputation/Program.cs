/*
Remember, triple slash for this documentation right before everything
so, you have categories, instrument and at this point customers
categories are set in stone and will contain more than just 1 instruments
instrument will have only one category (and if you want, we can change with nowadays kind) and at the contrary of what ya think, they'll not be attached to any client
they are there just to know they exist in the shop, otherwise making it have a quantity variable would be pointless
...or maybe a list of customers having this same product would be useful as a matter of statistic, or just to know who has it as a way to know what else
similat buyers usually buy as well(?).... welp, this application in origin was meant to be used by the owner of a shop, not by a user
customer can have more than one instruments, they aren't attached to categories and viceversa

model, view and controller... how should i divide their tasks?........

model has everything to work around the data, but it shouldn't at all print anything
view is only about graphical, possibly even input from the users
controller unite them for do everything

divide them in different folders btw, kay?
*/
class Program
{
    static void Main(string[] args)
    {
        Database model = new Database();
        View view = new View(model);
        Controller control = new Controller(model, view);
        using(model)
        {
            control.AvvioProgramma();
        }



        /*Console.WriteLine("Prove delle funzioni:");
        control.Preparation();*/
    }
}