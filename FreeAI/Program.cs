using FreeAI;

class Program
{
    static async Task Main(string[] args)
    {
        var FreeGPTAns = await FreeGPT.ASK("Как дела?");
        Console.WriteLine(FreeGPTAns); //Все отлично, спасибо! Как я могу помочь вам сегодня?

        var PolinationsAns = await Pollinations.Generate("Красивая природа");
        Console.WriteLine(PolinationsAns); //ans: img\63f21636-f813-4dd1-8b71-f4ec2f130f79.png

        /*-prompt(required): The text description of the image you want to generate.
        - model(optional): The model to use for generation. Options: 'flux' or 'turbo'. Default: 'turbo'
        - seed(optional): Seed for reproducible results. Default: random
        - width(optional): Width of the generated image. Default: 1024
        - height(optional): Height of the generated image. Default: 1024
        - nologo(optional): Set to 'true' to turn off the rendering of the logo
        - nofeed(optional): Set to 'true' to prevent the image from appearing in the public feed
        - enhance(optional) : Set to 'true' or 'false' to turn on or off prompt enhancing(passes prompts through an LLM to add detail)
        - folder: Folder for saving the image. Default: img*/
    }
}
