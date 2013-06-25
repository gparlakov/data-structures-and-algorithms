using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new Supermarket();
            var commandExecutor = new CommandExecutor(market);
            commandExecutor.ExecuteAllCommands();
            Console.WriteLine(commandExecutor.ResultMessages.ToString());
        }

        public class CommandExecutor
        {
            private const string OKmessage = "OK";
            private const string ErrorMessage = "Error";            

            private Supermarket market;

            private char[] separators;

            public CommandExecutor(Supermarket market)
            {
                this.market = market;
                this.ResultMessages = new StringBuilder();
                this.separators = new char[] { ' ' };
            }
            
            public StringBuilder ResultMessages { get; private set; }

            public void ExecuteAllCommands()
            {
                do
                {
                    var nextLine = Console.ReadLine().Split(this.separators, StringSplitOptions.RemoveEmptyEntries);
                    var command = GetCommand(nextLine[0]);
                    if (command == Command.End || command == Command.InvalidCommand)
                    {
                        break;
                    }
                    
                    ExecuteOneCommand(command, nextLine);
                } while (true);
                        
                
            }

            private void ExecuteOneCommand(Command command, string[] arguments)
            {
                var result = string.Empty;
                switch (command)
                {                       
                    case Command.Append:
                        {
                            this.market.Append(arguments[1]);
                            result = OKmessage;

                            break;
                        }
                    case Command.Insert:
                        {
                            var position = int.Parse(arguments[1]);
                            var name = arguments[2];
                            var inserted = this.market.Insert(position, name);
                            if (inserted)
                            {
                                result = OKmessage;
                            }
                            else
                            {
                                result = ErrorMessage;
                            }
                            
                            break;
                        }
                    case Command.Find:
                        {
                            result = this.market.Find(arguments[1]).ToString();

                            break;
                        }
                    case Command.Serve:
                        {
                            var countToServe = int.Parse(arguments[1]);
                            result = this.market.Serve(countToServe);
                            if (result == string.Empty)
                            {
                                result = ErrorMessage;
                            }

                            break;
                        }
                    case Command.End:
                    case Command.InvalidCommand:
                        {
                            throw new InvalidOperationException("Trying to execute invalid command!");                            
                        }
                    default:
                        break;
                }
                
                if (result!= string.Empty)
                {
                    this.ResultMessages.AppendLine(result);
                }               
            }

            private Command GetCommand(string commandString)
            {
                var command = Command.Append;
                for (var i = Command.Append; i <= Command.InvalidCommand; i++)
                {
                    if (i.ToString() == commandString)
                    {
                        command = i;
                        break;
                    }

                    if (i == Command.InvalidCommand)
                    {
                        command = Command.InvalidCommand;
                    }
                }

                return command;
            }

        }

        public enum Command
        {
            Append = 1,
            Insert = 2,
            Find = 3,
            Serve = 4,
            End = 5,
            InvalidCommand = 6
        }

        public class Supermarket
        {
            public LinkedList<string> Queue { get; set; }
            public Dictionary<string, int> Names { get; set; }
            public BigList<string> FastQueue { get; set; }

            public Supermarket()
            {
                this.Queue = new LinkedList<string>();
                this.Names = new Dictionary<string, int>();
                this.FastQueue = new BigList<string>();
            }

            public void Append(string name)
            {
                AddName(name);
                //this.Queue.AddLast(name);
                this.FastQueue.Add(name);
            }

            public bool Insert(int position, string name)
            {
                bool inserted = false;
                if (position > this.FastQueue.Count)
                {
                    return false;
                }

                if (position == 0)
                {
                    this.FastQueue.AddToFront(name);
                    this.AddName(name);
                    inserted = true;
                }
                else if(position == this.FastQueue.Count)
                {
                    this.FastQueue.Add(name);
                    this.AddName(name);
                    inserted = true;
                }
                else 
                {
                    this.FastQueue.Insert(position, name);
                    this.AddName(name);
                    inserted = true;                  
                }
                
                return inserted;
            }

            public int Find(string name)
            {
                var foundCount = 0;

                if (this.Names.ContainsKey(name))
                {
                    foundCount = this.Names[name];
                    if (foundCount < 0)
                    {
                        foundCount = 0;
                    }
                }

                return foundCount;
            }

            public string Serve(int count)
            {
                var namesServed = new StringBuilder();

                if (count <= this.FastQueue.Count)
                {
                    var counter = 0;                   

                    while (counter < count)
                    {
                        var person = this.FastQueue[0];
                        namesServed.Append(person + " ");
                        this.Names[person]--;
                        this.FastQueue.RemoveAt(0);
                        counter++;
                    }
                    namesServed.Length--;
                }

                return namesServed.ToString();
            }
                                
            private void AddName(string name)
            {
                if (!this.Names.ContainsKey(name))
                {
                    this.Names.Add(name, 1);
                }
                else
                {
                    //if (this.Names[name] < 0)
                    //{
                    //    this.Names[name] = 0;
                    //}
                    this.Names[name]++;
                }
            }

        }
    }
}
