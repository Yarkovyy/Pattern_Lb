using lb2_2.@interface;
using lb2_2.Model;
using lb2_2.service;
using lb2_2.service.Strategy;
using System.Net.Security;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;

Clan clan = new Clan(true, false, 'A');
Clan clan2 = new Clan(true, false, 'B');

GameManager gameManager = new GameManager(clan, clan2, false);
gameManager.StartGame();
