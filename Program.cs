
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
namespace MainRogue
{
    public class Scenes
    {
        public string Intro()
        {
            Console.WriteLine("Hello World!!!!!");
            Console.Write("What is your name player: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " welcome to ROGUELIKE!");

            Console.Beep(15000, 100);
            Console.Beep(4500, 100);
            Console.Beep(4000, 100);
            Console.Beep(3300, 100);
            Console.Beep(2000, 100);
            Console.Beep(1000, 100);
            Console.Beep(500, 100);
            return name;
        }
    }
    public class GameData
    {
        public List<char[]> mapLayers = new List<char[]>();
        public Dictionary<string, string> Info = new Dictionary<string, string>();
        public List<string> messagesList = new List<string>();
        public Dictionary<string, string> Messages = new Dictionary<string, string>();
        public string name;

        public void MapData()
        {
            string layer0 = "%%%%%%%%%%%%%%#_##%%%%%%%%%%%%##########%  " + name + "'s Lives:<3<3<3                        ";
            string layer1 = "%%          %%# ##############   {+}   #%  Coins:000000                         ";
            string layer2 = "%%%%%%%%%%% %%#             |          #%  |---------------------------------|  ";
            string layer3 = "%#########% %############## ###        #%  | Info| Messages| Inventory| Notes|  ";
            string layer4 = "%#*******#% %#         #%%# #%#     ~  #%  |---------------------------------|  ";
            string layer5 = "%#*******#% %#    ?    #%%# #%#        #%  |                                 |  ";
            string layer6 = "%#*******#%%%#         #%%# #%#        #%  |                                 |  ";
            string layer7 = "%##### ####### ####### #### ###        #%  |                                 |  ";
            string layer8 = "% %#                ##      |          #%  |                                 |  ";
            string layer9 = "% %#        ####### ####################%  |                                 |  ";
            string layer10 = "% %##########%%%%%# #%%%%%%%%#         #%  |                                 |  ";
            string layer11 = "%%%%%%%%%%%%%%##### #####%####     ~   #%  |                                 |  ";
            string layer12 = "%            %#   ( )   ##             #%  |                                 |  ";
            string layer13 = "%            %#         \\              #%  |                                 |  ";
            string layer14 = "%            %#   @     ##             #%  |                                 |  ";
            string layer15 = "%            %###########%##############%  |                                 |  ";
            string layer16 = "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%  |_________________________________|  ";
            string layer17 = "-Talk -----------------------------------------------------------------------| ";
            string layer18 = "|                                                                            |  ";
            string layer19 = "|                                                                            |  ";
            string layer20 = "|____________________________________________________________________________|  ";



            mapLayers.Add(layer0.ToCharArray());
            mapLayers.Add(layer1.ToCharArray());
            mapLayers.Add(layer2.ToCharArray());
            mapLayers.Add(layer3.ToCharArray());
            mapLayers.Add(layer4.ToCharArray());
            mapLayers.Add(layer5.ToCharArray());
            mapLayers.Add(layer6.ToCharArray());
            mapLayers.Add(layer7.ToCharArray());
            mapLayers.Add(layer8.ToCharArray());
            mapLayers.Add(layer9.ToCharArray());
            mapLayers.Add(layer10.ToCharArray());
            mapLayers.Add(layer11.ToCharArray());
            mapLayers.Add(layer12.ToCharArray());
            mapLayers.Add(layer13.ToCharArray());
            mapLayers.Add(layer14.ToCharArray());
            mapLayers.Add(layer15.ToCharArray());
            mapLayers.Add(layer16.ToCharArray());
            mapLayers.Add(layer17.ToCharArray());
            mapLayers.Add(layer18.ToCharArray());
            mapLayers.Add(layer19.ToCharArray());
            mapLayers.Add(layer20.ToCharArray());

        }
        public void ConsoleData()
        {
            Messages.Add("  [Hello]-", " You have entered a haunted mansion, you better start running to an Exit!");
            Messages.Add("  [Precious Coins!]-", " Collect 15 coins so you can catch the first bus out of town.");
            Messages.Add("  [Find a key]-", " Aquire the key for the master bedroom, maybe there's some thing worth stealing.");

            Info.Add("  ? = ", "Key");
            Info.Add("  ~ = ", "Note");
            Info.Add("  * = ", "Coin");
            Info.Add("  @ = ", "Player");
            Info.Add("  {+} = ", "Chest");
            Info.Add("  / = ", "Open Door");
            Info.Add("  | = ", "Closed Door");

            foreach (var item in Messages)
            {
                messagesList.Add(item.Key.ToString());
            }
        }
    }
    public class Events
    {
        public bool run = true;
        public int index = 5;
        public int playery = 14;
        public int playerx = 18;

        public int coinx = 54;
        public int coiny = 1;

        public int coins = 0;

        public bool message = true;
        public bool readMessage = false;
        public bool info = false;
        public bool inventory = false;
        public bool notes = false;

        int totalMessages = 0;
        int totalInventory = 0;
        int totalNotes = 0;

        public string keys;

        /// CLEARS THE SCREEN FOR TRANSITION
        /// <param name="mapLayers"></param>
        public void clearConsole(List<char[]> mapLayers)
        {
            for (int y = 4; y < 17; y++)
                for (int x = 43; x < 77; x++)
                {
                    char[] layer = mapLayers[y];
                    if (x > 43 && x < 77 && y > 4 && y < 16) { layer[x] = ' '; }
                    mapLayers[y] = layer;
                }
        }
      
        /// COLLECTS COINS
        /// </summary>
        /// <param name="mapLayers"></param>
        /// <param name="location"></param>
        /// <param name="playerx"></param>
        /// <param name="coinx"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int CoinCollector(List<char[]> mapLayers, char location, int playerx, int coinx, int coins)
        {
            char[] coinLayer = mapLayers[coiny];
            if (location == '*')
            {
                coins++;
                string coinsString = coins.ToString();
                char[] coinsArray = coinsString.ToCharArray();

                if (coins > 9)
                {
                    ///coinsArray = coinsString.First();
                    coinLayer[coinx - 1] = coinsArray[0];
                    coinLayer[coinx] = coinsArray[1];
                }
                else { coinLayer[coinx] = coinsArray[0]; }

                Console.Beep(30000, 100);
                Console.Beep(25000, 100);
                return coins;
            }
            else { return coins; }
        }

        /// CHECK PLAYER EVENTS
        /// </summary>
        /// <param name="mapLayers"></param>
        /// <param name="messages"></param>
        /// <param name="messagesList"></param>
        public void CheckEvents(List<char[]> mapLayers, Dictionary<string, string> messages, List<string> messagesList)
        {

            keys = Console.ReadKey().Key.ToString();

            if (keys.ToLower() == "a")
            {
                char[] layer = mapLayers[playery];
                if (layer[playerx - 1] != '#' && layer[playerx - 1] != '|')
                {
                    coins = CoinCollector(mapLayers, layer[playerx - 1], playerx, coinx, coins);
                    if (layer[playerx - 1] == '/')
                    {
                        layer[playerx] = ' ';
                        layer[playerx - 1] = '\\';
                        playerx = playerx - 2;
                        layer[playerx] = '@';
                        Console.Beep(5000, 100);
                    }

                    else
                    {
                        layer[playerx] = ' ';
                        playerx--;
                        layer[playerx] = '@';
                        mapLayers[playery] = layer;
                    }
                }
            }

            if (keys.ToLower() == "d")
            {
                char[] layer = mapLayers[playery];
                if (layer[playerx + 1] != '#' && layer[playerx + 1] != '|')
                {
                    coins = CoinCollector(mapLayers, layer[playerx + 1], playerx, coinx, coins);
                    if (layer[playerx + 1] == '\\')
                    {
                        layer[playerx] = ' ';
                        layer[playerx + 1] = '/';
                        playerx = playerx + 2;
                        layer[playerx] = '@';
                        Console.Beep(5000, 100);
                    }

                    else
                    {
                        layer[playerx] = ' ';
                        playerx++;
                        layer[playerx] = '@';
                        mapLayers[playery] = layer;
                    }
                }
                else
                {
                    Console.Beep(30000, 100);
                }
            }

            if (keys.ToLower() == "w")
            {
                char[] layer = mapLayers[playery];
                char[] upperLayer = mapLayers[playery - 1];
                if (upperLayer[playerx] != '#')
                {
                    coins = CoinCollector(mapLayers, upperLayer[playerx], playerx, coinx, coins);
                    layer[playerx] = ' ';
                    upperLayer[playerx] = '@';
                    mapLayers[playery] = layer;
                    playery--;
                    mapLayers[playery] = upperLayer;
                }
                else
                {
                    Console.Beep(30000, 100);
                }
            }

            if (keys.ToLower() == "s")
            {
                char[] layer = mapLayers[playery];
                char[] upperLayer = mapLayers[playery + 1];
                if (upperLayer[playerx] != '#')
                {
                    coins = CoinCollector(mapLayers,upperLayer[playerx], playerx, coinx, coins);
                    layer[playerx] = ' ';
                    upperLayer[playerx] = '@';
                    mapLayers[playery] = layer;
                    playery++;
                    mapLayers[playery] = upperLayer;
                }
                else
                {
                    Console.Beep(30000, 100);
                }
            }
            if (keys.ToLower() == "q")
                run = false;

            if (keys.ToLower() == "u" && message)
            {
                message = false;
                index = 5;
                info = true;
                clearConsole(mapLayers);
                Console.Beep(7000, 100);
            }
            else if (keys.ToLower() == "u" && info)
            {
                info = false;
                notes = true;
                index = 5;
                clearConsole(mapLayers);
                Console.Beep(7000, 100);
            }
            else if (keys.ToLower() == "u" && notes)
            {
                notes = false;
                inventory = true;
                index = 5;
                clearConsole(mapLayers);
                Console.Beep(7000, 100);
            }
            else if (keys.ToLower() == "u" && inventory)
            {
                inventory = false;
                message = true;
                index = 5;
                clearConsole(mapLayers);
                Console.Beep(7000, 100);
                ///char[] layer = mapLayers[5];
                ///layer[44] = '>';
                ///mapLayers[5] = layer;

            }
            Thread.Sleep(1);
        }

        /// DRAW TO SCREEN
        /// </summary>
        /// <param name="mapLayers"></param>
        public void Draw(List<char[]>mapLayers)
        {
            for (int y = 0; y < 21; y++)
                for (int x = 0; x < 79; x++)
                {

                    char[] layer = mapLayers[y];
                    if (message && x > 50 && x < 59 && y == 3) { Console.ForegroundColor = ConsoleColor.Red; }

                    else if (info && x > 44 && x < 49 && y == 3) { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (inventory && x > 60 && x < 70 && y == 3) { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (notes && x > 71 && x < 77 && y == 3) { Console.ForegroundColor = ConsoleColor.Red; }

                    else if (layer[x] == '#') { Console.ForegroundColor = ConsoleColor.DarkGray; }
                    else if (layer[x] == '%') { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                    else if (layer[x] == '@') { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (layer[x] == '*') { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                    else if (layer[x] == '_') { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (layer[x] == '|') { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (layer[x] == '~') { Console.ForegroundColor = ConsoleColor.White; }
                    else if (layer[x] == '?') { Console.ForegroundColor = ConsoleColor.Magenta; }
                    else if (layer[x] == '[' || layer[x] == ']') { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (layer[x] == '{' || layer[x] == '}') { Console.ForegroundColor = ConsoleColor.Blue; }
                    else if (layer[x] == '<' || layer[x] == '3' && y == 0) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                    else if (layer[x] == '>') { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (layer[x] == '+') { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                    ///else if (message && x > 43 && x < 77 && y > 4 && y < 16) { Console.ForegroundColor = ConsoleColor.DarkGray; }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (x == 78)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(layer[x]);
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(layer[x]);
                    }
                }
            Console.SetCursorPosition(0, 21);
        }
    }
    public class PlayerConsole
    {
        public int xStart = 44;
        public int yStart = 5;

        public int xStop = 75;
        public int yStop = 17;

        public int index = 5;

        public bool readMessage = false;

        /// CLEARS THE CONSOLE FOR SCREEN TRANSITION
        /// <param name="mapLayers"></param>
        public void clearConsole(List<char[]> mapLayers)
        {
            for (int y = 4; y < 17; y++)
                for (int x = 43; x < 77; x++)
                {
                    char[] layer = mapLayers[y];
                    if (x > 43 && x < 77 && y > 4 && y < 16) { layer[x] = ' '; }
                    mapLayers[y] = layer;
                }
        }

        ///     MESSAGES BAR
        /// Displays THE PLAYERS MESSAGES
        /// <param name="mapLayers"></param>
        /// <param name="Messages"></param>
        public void DisplayMessages(List<char[]> mapLayers, Dictionary<string, string> Messages)
        {
            int x = xStart;
            int y = yStart;
            int messageNum = 0;
            foreach (var item in Messages)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (i < item.Key.Length && x < 75)
                    {
                        char[] layer = mapLayers[y];
                        layer[x] = item.Key[i];
                        x++;

                    }
                    else if (i > item.Key.Length && x < 72)
                    {
                        char[] layer = mapLayers[y];
                        layer[x] = item.Value[messageNum];
                        messageNum++;
                        x++;
                    }

                    else if (x > 71 && x < 75)
                    {
                        char[] layer = mapLayers[y];
                        layer[x] = '.';
                        messageNum++;
                        x++;
                        ///x = 44;
                        ///messageNum = 0;
                        ///continue;

                    }
                }
                x = xStart;
                messageNum = 0;
                y++;
            }
        }
        /// SELECT MESSAGE
        /// <param name="Messages"></param>
        /// <param name="messagesList"></param>
        /// <param name="index"></param>
        /// <param name="mapLayers"></param>
        /// <param name="keys"></param>
        public void SelectMessage(Dictionary<string, string> Messages, List<string> messagesList, List<char[]> mapLayers, string keys)
        {
            char[] ystart = mapLayers[5];
            char[] yend = mapLayers[5 + messagesList.Count - 1];
            if (index == 5) { ystart[xStart] = '>'; }
            else if (index == 5 + messagesList.Count - 1) { yend[xStart] = '>'; }
            if (keys.ToLower() == "y" && index != 4)
            {
                if (index > 5)
                {
                    readMessage = false;
                    ///clearConsole(mapLayers);
                    DisplayMessages(mapLayers, Messages);
                    index--;
                    char[] layer = mapLayers[index];
                    char[] lowerLayer = mapLayers[index + 1];
                    layer[xStart] = '>';
                    lowerLayer[xStart] = ' ';
                    mapLayers[index] = layer;
                    mapLayers[index + 1] = lowerLayer;
                    Console.Beep(7300, 100);
                }


            }
            else if (keys.ToLower() == "h" && index != 5 + messagesList.Count)
            {
                if (index < 5 + messagesList.Count - 1)
                {
                    readMessage = false;
                    ///clearConsole(mapLayers);
                    DisplayMessages(mapLayers, Messages);
                    index++;
                    char[] layer = mapLayers[index];
                    char[] upperLayer = mapLayers[index - 1];
                    layer[xStart] = '>';
                    upperLayer[xStart] = ' ';
                    mapLayers[index - 1] = upperLayer;
                    mapLayers[index] = layer;
                    Console.Beep(7300, 100);
                }
            }
            else if (keys.ToLower() == "o") { readMessage = true; }///index = 5; }
        }
        /// OPEN SELECTED MESSAGE
        /// </summary>
        /// <param name="Messages"></param>
        /// <param name="messagesList"></param>
        /// <param name="mapLayers"></param>
        /// <param name="keys"></param>
        public void OpenMessage(Dictionary<string, string> Messages, List<string> messagesList, List<char[]> mapLayers, string keys)
        {

            clearConsole(mapLayers);
            char[] message = Messages[messagesList[index - 5]].ToCharArray();
            char[] messageArray = messagesList[index - 5].ToCharArray();
            char[] headerLayer = mapLayers[5];
            for (int i = 44; i < 75 && i < messageArray.Count() + 44; i++)
            {
                headerLayer[i] = messageArray[i - 44];
                mapLayers[5] = headerLayer;
            }
            int z = 0;
            for (int y = 6; y < yStop; y++)
                for (int x = 44; x < xStop; x++)
                {
                    if (x > 68 && z < message.Count() && message[z] == ' ')
                    {
                        continue;
                    }
                    else if (z < message.Count())
                    {
                        char[] newLayer = mapLayers[y];
                        newLayer[x] = message[z];
                        mapLayers[y] = newLayer;
                        z++;
                    }

                    else { continue; index = 5; }
                }
            if (keys.ToLower() != "o") { clearConsole(mapLayers); readMessage = false; DisplayMessages(mapLayers, Messages); SelectMessage(Messages, messagesList, mapLayers, keys); }
        }

        /// INFO BAR
        /// </summary>
        /// <param name="mapLayers"></param>
        /// <param name="Info"></param>
        public void DisplayInfo(List<char[]> mapLayers, Dictionary<string, string> Info)
        {
            int x = 44;
            int y = 5;
            int messageNum = 0;
            foreach (var item in Info)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (i < item.Key.Length && x < 75)
                    {
                        char[] layer = mapLayers[y];
                        layer[x] = item.Key[i];
                        x++;

                    }
                    else if (i > item.Key.Length && item.Value.Length > messageNum)
                    {
                        char[] layer = mapLayers[y];
                        layer[x] = item.Value[messageNum];
                        messageNum++;
                        x++;
                    }

                    else if (x > 71 && x < 75)
                    {
                        char[] layer = mapLayers[y];
                        layer[x] = '.';
                        messageNum++;
                        x++;
                        ///x = 44;
                        ///messageNum = 0;
                        ///continue;

                    }
                }
                x = 44;
                messageNum = 0;
                y++;
            }
        }

        /// CHECK CONSOLE EVENTS
        /// </summary>
        /// <param name="message"></param>
        /// <param name="info"></param>
        /// <param name="inventory"></param>
        /// <param name="notes"></param>
        public void CheckConsole(bool message, bool info, bool inventory, bool notes, List<char[]>mapLayers, List<string>messagesList,Dictionary<string,string>Messages, Dictionary<string,string>Info, string keys)
        {
            if (message && readMessage == false)
            {
                ///messageBoard.clearConsole(data.mapLayers);
                DisplayMessages(mapLayers, Messages);
                SelectMessage(Messages, messagesList, mapLayers, keys);
            }
            if (message && readMessage)
            {
                ///SelectMessage(Messages, messagesList, mapLayers, keys);
                OpenMessage(Messages, messagesList, mapLayers, keys);
            }
            if (message == false) { readMessage = false; index = 5; }
            if (info) { DisplayInfo(mapLayers, Info); }
            ///else { clearConsole(mapLayers);}
        }
    }
    public class Ghost
    {
        public int x = 19;
        public int y = 5;
        public char ghostChar = 'O';

        public void UpdateGhost(int playerx, int playery, List<char[]> mapLayers)
        {
            char[] layer = mapLayers[y];
///            if (y<playery )
///            {
            if (y > playery)
            {
                if (playery - y > playerx - x && mapLayers[y - 1][x] != '#' && x!=playerx && layer[x-1]!= '@') { y -= 1; layer[x] = ' '; layer = mapLayers[y]; layer[x] = ghostChar; }
                else if (x < playerx && layer[x+1]!= '#'){ x += 1; layer[x] = ghostChar; layer[x - 1] = ' '; }
                else if (x > playerx && layer[x - 1] != '#') { x -= 1; layer[x] = ghostChar; layer[x + 1] = ' '; }
                else if (mapLayers[y - 1][x] != '#') { y -= 1; layer[x] = ' '; layer = mapLayers[y]; layer[x] = ghostChar; }
            }
            else if (y < playery)
            {
                if (y - playery > x - playerx && mapLayers[y + 1][x] != '#' && x != playerx && layer[x + 1] != '@') { y += 1; layer[x] = ' '; layer = mapLayers[y]; layer[x] = ghostChar; }
                else if (x > playerx && layer[x - 1] != '#') { x -= 1; layer[x] = ghostChar; layer[x + 1] = ' '; }
                else if (x < playerx && layer[x + 1] != '#') { x += 1; layer[x] = ghostChar; layer[x - 1] = ' '; }
                else if (mapLayers[y + 1][x] != '#') { y += 1; layer[x] = ' '; layer = mapLayers[y]; layer[x] = ghostChar; }
            }
            else if (y == playery)
            {
                if (x > playerx && layer[x - 1] != '#') { x -= 1; layer[x] = ghostChar; layer[x + 1] = ' '; }
                else if (x < playerx && layer[x + 1] != '#') { x += 1; layer[x] = ghostChar; layer[x - 1] = ' '; }
            }
///            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var data = new GameData();
            var events = new Events();
            var scene = new Scenes();
            var console = new PlayerConsole();
            var newGhost = new Ghost();
            
            data.name = scene.Intro();
            data.MapData();
            data.ConsoleData();


            int wx = 0;
            int wy = 0;
            System.Threading.Thread.Sleep(150);

            Console.Clear();

            Console.CursorVisible = false;
            
            Console.SetWindowPosition(wx, wy);
            wy = wy + 17;
            while (events.run)
            {
                Console.CursorVisible = false;
                ///Console.BackgroundColor = ConsoleColor.Magenta;
                events.Draw(data.mapLayers);
                /// Checking PLayer Input
                events.CheckEvents(data.mapLayers, data.Messages, data.messagesList);
                newGhost.UpdateGhost(events.playerx, events.playery, data.mapLayers);
                console.CheckConsole(events.message, events.info, events.inventory, events.notes, data.mapLayers, data.messagesList, data.Messages, data.Info, events.keys);
                ///System.Threading.Thread.Sleep(0);
            }

        }
    }
}
