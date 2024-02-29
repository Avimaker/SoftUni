/*
0882134215 0882134333 0899213421 0558123 3333123
http://softuni.bg http://youtube.com http://www.g00gle.com
*/

using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
engine.Run();