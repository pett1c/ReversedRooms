using System.Collections.Generic;
using Reversedrooms.Models;
using Reversedrooms.Models.Enemy;
using Reversedrooms.Models.Items;

namespace Reversedrooms.Data.LevelData
{
    public static class Level0
    {
        public static List<Location> CreateLevel()
        {
            var locations = new List<Location>();

            // Initialize all locations based on the map
            // First Row (IDs: 9, 14, 18)
            var nothingRoom1 = new Location("Nothing Room", "An empty room with damp carpet and buzzing lights.", false); // ID: 9
            var liftRoom = new Location("Lift Room", "A small room with a rusty lift. It might take you somewhere else.", false); // ID: 14
            var nothingRoom2 = new Location("Nothing Room", "An empty room with damp carpet and buzzing lights.", false); // ID: 18

            // Second Row (IDs: 7, 8, 10, 13, 16, 17, 21)
            var nothingRoomDark1 = new Location("Nothing Room", "A dark room with no visible light. The air feels heavy.", true); // ID: 7
            var enemyRoomDeathmoth1 = new Location("Enemy Room", "A room with a faint buzzing sound. Something moves in the shadows.", false); // ID: 8
            var enemyRoomSmiler1 = new Location("Enemy Room", "A room with a glowing smile in the darkness. It watches you.", false); // ID: 10
            var bossRoom = new Location("Boss Room", "A large room with a tall figure in the center. It looks dangerous.", false); // ID: 13
            var enemyRoomSmiler2 = new Location("Enemy Room", "A room with a glowing smile in the darkness. It watches you.", false); // ID: 16
            var enemyRoomDeathmoth2 = new Location("Enemy Room", "A room with a faint buzzing sound. Something moves in the shadows.", false); // ID: 17
            var nothingRoomDark2 = new Location("Nothing Room", "A dark room with no visible light. The air feels heavy.", true); // ID: 21

            // Third Row (IDs: 6, 5, 11, 12, 15, 19, 20)
            var collectRoomBatteries1 = new Location("Collect Room", "A room with some batteries scattered on the floor.", false); // ID: 6
            var collectRoomAlmondWater1 = new Location("Collect Room", "A room with a bottle of almond water on a table.", false); // ID: 5
            var nothingRoomDark3 = new Location("Nothing Room", "A dark room with no visible light. The air feels heavy.", true); // ID: 11
            var collectRoomAlmondWater2 = new Location("Collect Room", "A room with a bottle of almond water on a table.", false); // ID: 12
            var nothingRoomDark4 = new Location("Nothing Room", "A dark room with no visible light. The air feels heavy.", true); // ID: 15
            var collectRoomAlmondWater3 = new Location("Collect Room", "A room with a bottle of almond water on a table.", false); // ID: 19
            var collectRoomBatteries2 = new Location("Collect Room", "A room with some batteries scattered on the floor.", false); // ID: 20

            // Fourth Row (IDs: 4, 2, 1, 0, 24, 22, 23)
            var nothingRoom3 = new Location("Nothing Room", "An empty room with damp carpet and buzzing lights.", false); // ID: 4
            var enemyRoomSmiler3 = new Location("Enemy Room", "A room with a glowing smile in the darkness. It watches you.", false); // ID: 2
            var collectRoomMapAlmond = new Location("Collect Room", "A room with a map on the wall and a bottle of almond water.", false); // ID: 1
            var mainRoom = new Location("Main Room", "A strange yellow corridor with buzzing fluorescent lights.", false); // ID: 0
            var nothingRoomDark5 = new Location("Nothing Room", "A dark room with no visible light. The air feels heavy.", true); // ID: 24
            var enemyRoomSmiler4 = new Location("Enemy Room", "A room with a glowing smile in the darkness. It watches you.", false); // ID: 22
            var nothingRoom4 = new Location("Nothing Room", "An empty room with damp carpet and buzzing lights.", false); // ID: 23

            // Fifth Row (ID: 3)
            var nothingRoom5 = new Location("Nothing Room", "An empty room with damp carpet and buzzing lights.", false); // ID: 3

            // Assign items to Collect Rooms
            collectRoomBatteries1.Items.Add(new ConsumableItem("Batteries", "A pack of batteries for your flashlight.", 1));
            collectRoomBatteries2.Items.Add(new ConsumableItem("Batteries", "A pack of batteries for your flashlight.", 1));
            collectRoomAlmondWater1.Items.Add(new ConsumableItem("Almond Water", "A bottle of almond water. It might help your sanity.", 1));
            collectRoomAlmondWater2.Items.Add(new ConsumableItem("Almond Water", "A bottle of almond water. It might help your sanity.", 1));
            collectRoomAlmondWater3.Items.Add(new ConsumableItem("Almond Water", "A bottle of almond water. It might help your sanity.", 1));
            collectRoomMapAlmond.Items.Add(new ConsumableItem("Almond Water", "A bottle of almond water. It might help your sanity.", 1));
            collectRoomMapAlmond.Items.Add(new Note("Map on the wall", "A crude map of the area. It shows the layout of this level."));

            // Assign enemies to Enemy Rooms and Boss Room
            enemyRoomSmiler1.Enemy = new Smiler();
            enemyRoomSmiler2.Enemy = new Smiler();
            enemyRoomSmiler3.Enemy = new Smiler();
            enemyRoomSmiler4.Enemy = new Smiler();
            enemyRoomDeathmoth1.Enemy = new DeathMoth();
            enemyRoomDeathmoth2.Enemy = new DeathMoth();
            bossRoom.Enemy = new SkinThief();

            // Set connections between locations based on the provided exits
            // ID 0: Left: ID1; Right: ID24
            mainRoom.AddConnection(Direction.Left, collectRoomMapAlmond);
            mainRoom.AddConnection(Direction.Right, nothingRoomDark5);

            // ID 1: Left: ID2; Right: ID0
            collectRoomMapAlmond.AddConnection(Direction.Left, enemyRoomSmiler3);
            collectRoomMapAlmond.AddConnection(Direction.Right, mainRoom);

            // ID 2: Left: ID4; Right: ID1; Up: ID5; Down: ID3
            enemyRoomSmiler3.AddConnection(Direction.Left, nothingRoom3);
            enemyRoomSmiler3.AddConnection(Direction.Right, collectRoomMapAlmond);
            enemyRoomSmiler3.AddConnection(Direction.Up, collectRoomAlmondWater1);
            enemyRoomSmiler3.AddConnection(Direction.Down, nothingRoom5);

            // ID 3: Up: ID2
            nothingRoom5.AddConnection(Direction.Up, enemyRoomSmiler3);

            // ID 4: Right: ID2
            nothingRoom3.AddConnection(Direction.Right, enemyRoomSmiler3);

            // ID 5: Left: ID6; Up: ID8; Down: ID2
            collectRoomAlmondWater1.AddConnection(Direction.Left, collectRoomBatteries1);
            collectRoomAlmondWater1.AddConnection(Direction.Up, enemyRoomDeathmoth1);
            collectRoomAlmondWater1.AddConnection(Direction.Down, enemyRoomSmiler3);

            // ID 6: Right: ID5; Up: ID7
            collectRoomBatteries1.AddConnection(Direction.Right, collectRoomAlmondWater1);
            collectRoomBatteries1.AddConnection(Direction.Up, nothingRoomDark1);

            // ID 7: Down: ID6
            nothingRoomDark1.AddConnection(Direction.Down, collectRoomBatteries1);

            // ID 8: Right: ID10; Up: ID9; Down: ID5
            enemyRoomDeathmoth1.AddConnection(Direction.Right, enemyRoomSmiler1);
            enemyRoomDeathmoth1.AddConnection(Direction.Up, nothingRoom1);
            enemyRoomDeathmoth1.AddConnection(Direction.Down, collectRoomAlmondWater1);

            // ID 9: Down: ID8
            nothingRoom1.AddConnection(Direction.Down, enemyRoomDeathmoth1);

            // ID 10: Left: ID8; Down: ID11
            enemyRoomSmiler1.AddConnection(Direction.Left, enemyRoomDeathmoth1);
            enemyRoomSmiler1.AddConnection(Direction.Down, nothingRoomDark3);

            // ID 11: Right: ID12; Up: ID10
            nothingRoomDark3.AddConnection(Direction.Right, collectRoomAlmondWater2);
            nothingRoomDark3.AddConnection(Direction.Up, enemyRoomSmiler1);

            // ID 12: Left: ID11; Right: ID15; Up: ID13
            collectRoomAlmondWater2.AddConnection(Direction.Left, nothingRoomDark3);
            collectRoomAlmondWater2.AddConnection(Direction.Right, nothingRoomDark4);
            collectRoomAlmondWater2.AddConnection(Direction.Up, bossRoom);

            // ID 13: Up: ID14; Down: ID12
            bossRoom.AddConnection(Direction.Up, liftRoom);
            bossRoom.AddConnection(Direction.Down, collectRoomAlmondWater2);

            // ID 14: Down: ID13
            liftRoom.AddConnection(Direction.Down, bossRoom);

            // ID 15: Left: ID12; Up: ID16
            nothingRoomDark4.AddConnection(Direction.Left, collectRoomAlmondWater2);
            nothingRoomDark4.AddConnection(Direction.Up, enemyRoomSmiler2);

            // ID 16: Right: ID17; Down: ID15
            enemyRoomSmiler2.AddConnection(Direction.Right, enemyRoomDeathmoth2);
            enemyRoomSmiler2.AddConnection(Direction.Down, nothingRoomDark4);

            // ID 17: Left: ID16; Up: ID18; Down: ID19
            enemyRoomDeathmoth2.AddConnection(Direction.Left, enemyRoomSmiler2);
            enemyRoomDeathmoth2.AddConnection(Direction.Up, nothingRoom2);
            enemyRoomDeathmoth2.AddConnection(Direction.Down, collectRoomAlmondWater3);

            // ID 18: Down: ID17
            nothingRoom2.AddConnection(Direction.Down, enemyRoomDeathmoth2);

            // ID 19: Right: ID20; Up: ID17; Down: ID22
            collectRoomAlmondWater3.AddConnection(Direction.Right, collectRoomBatteries2);
            collectRoomAlmondWater3.AddConnection(Direction.Up, enemyRoomDeathmoth2);
            collectRoomAlmondWater3.AddConnection(Direction.Down, enemyRoomSmiler4);

            // ID 20: Left: ID19; Up: ID21
            collectRoomBatteries2.AddConnection(Direction.Left, collectRoomAlmondWater3);
            collectRoomBatteries2.AddConnection(Direction.Up, nothingRoomDark2);

            // ID 21: Down: ID20
            nothingRoomDark2.AddConnection(Direction.Down, collectRoomBatteries2);

            // ID 22: Left: ID24; Right: ID23; Up: ID19
            enemyRoomSmiler4.AddConnection(Direction.Left, nothingRoomDark5);
            enemyRoomSmiler4.AddConnection(Direction.Right, nothingRoom4);
            enemyRoomSmiler4.AddConnection(Direction.Up, collectRoomAlmondWater3);

            // ID 23: Left: ID22
            nothingRoom4.AddConnection(Direction.Left, enemyRoomSmiler4);

            // ID 24: Left: ID0; Right: ID22
            nothingRoomDark5.AddConnection(Direction.Left, mainRoom);
            nothingRoomDark5.AddConnection(Direction.Right, enemyRoomSmiler4);

            // Add all locations to the list
            locations.AddRange(new[]
            {
                nothingRoom1, liftRoom, nothingRoom2,
                nothingRoomDark1, enemyRoomDeathmoth1, enemyRoomSmiler1, bossRoom, enemyRoomSmiler2, enemyRoomDeathmoth2, nothingRoomDark2,
                collectRoomBatteries1, collectRoomAlmondWater1, nothingRoomDark3, collectRoomAlmondWater2, nothingRoomDark4, collectRoomAlmondWater3, collectRoomBatteries2,
                nothingRoom3, enemyRoomSmiler3, collectRoomMapAlmond, mainRoom, nothingRoomDark5, enemyRoomSmiler4, nothingRoom4,
                nothingRoom5
            });

            return locations;
        }

        public static Location GetStartingLocation(List<Location> locations)
        {
            return locations.Find(loc => loc.Name == "Main Room");
        }
    }
}