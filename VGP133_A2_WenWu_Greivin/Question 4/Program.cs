// See https://aka.ms/new-console-template for more information

//Question 4
using Question_4;

Motorway motorway1 = new Motorway("Cambie");
Motorway motorway2 = new Motorway("Brentwood", 'E', 3, false, "AlfredoCo");
Motorway motorway3 = new Motorway("Metrotown", 'W', 2, true, "JPNCO");

//cambie
motorway1.GetDirectionName();
motorway1.IsTollRoad();
//brentwood
motorway2.GetDirectionName();
motorway2.IsTollRoad();
//metrotown
motorway3.GetDirectionName();
motorway3.IsTollRoad();