using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Brevitee.CommandLine;
using Brevitee;
using Brevitee.Data;
using Brevitee.Testing;
using Brevitee.Encryption;
using Brevitee.BattleStickers.Business.Data;

namespace Brevitee.BattleStickers.Business.Data.Tests
{
    [Serializable]
    class Program : CommandLineTestInterface
    {
        static void Main(string[] args)
        {
            PreInit();
            Initialize(args);
        }

        public static void PreInit()
        {
            #region expand for PreInit help
            // To accept custom command line arguments you may use            
            /*
             * AddValidArgument(string argumentName, bool allowNull)
            */

            // All arguments are assumed to be name value pairs in the format
            // /name:value unless allowNull is true then only the name is necessary.

            // to access arguments and values you may use the protected member
            // arguments. Example:

            /*
             * arguments.Contains(argName); // returns true if the specified argument name was passed in on the command line
             * arguments[argName]; // returns the specified value associated with the named argument
             */

            // the arguments protected member is not available in PreInit() (this method)
            #endregion
        }

        [ConsoleAction("Add your action here")]
        public void AddYourActionHere()
        {
        }

        class TestCharacter: Character
        {

        }

        class TestEquipment: Equipment
        {

            #region IEquipment Members

            public void Effect(Character character)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        //List<Dao> _toBeDeleted;
        public void First()
        {
            SQLiteRegistrar.Register("BattleStickers");
            Db.TryEnsureSchema<Battle>();

            //_toBeDeleted = new List<Dao>();
            //Dao.AfterCommitAny += (db, dao) =>
            //{
            //    _toBeDeleted.Add(dao);
            //};
        }

        public void After()
        {
            //_toBeDeleted.Each(d =>
            //{
            //    d.Delete();
            //});
        }
        
        [UnitTest]
        public void BattleStateShouldBePendingSetBattleTypeAfterCreate()
        {
			First();
            Battle battle = StartTestBattle();
            Expect.IsTrue(battle.State == BattleState.PendingSetBattleType);
			After();
        }

        [UnitTest]
        public void BattleStateShouldBePendingSelectionsAfterSetBattleType()
        {
			First();
            Battle battle = StartTestBattle();
            Expect.IsTrue(battle.State == BattleState.PendingSetBattleType);
            battle.SetBattleType(BattleType.Three);
            Expect.IsTrue(battle.State == BattleState.PendingSelections);
        }

        [UnitTest]
        public void BattleStateShouldBePendingPlayerTwoSelectionsIfPlayerOneSelections()
        {
			First();
            Battle battle = StartTestBattle();
            Expect.IsTrue(battle.State == BattleState.PendingSetBattleType);
            battle.SetBattleType(BattleType.Three);
            Expect.IsTrue(battle.State == BattleState.PendingSelections);
            battle.SetPlayerOneSelections(CreatePlayerOneSelections());
            Expect.IsTrue(battle.State == BattleState.PendingPlayerTwoSelections);
        }

        [UnitTest]
        public void BattleStateShouldBePendingPlayerOneSelectionsIfPlayerTwoSelections()
        {
			First();
            Battle battle = StartTestBattle();
            Expect.IsTrue(battle.State == BattleState.PendingSetBattleType);
            battle.SetBattleType(BattleType.Three);
            Expect.IsTrue(battle.State == BattleState.PendingSelections);
            battle.SetPlayerTwoSelections(CreatePlayerTwoSelections());
            Expect.IsTrue(battle.State == BattleState.PendingPlayerOneSelections);
        }

        [UnitTest]
        public void BattleStateShouldBeRockPaperScissorsAfterSelection()
        {
			First();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(CreatePlayerOneSelections());
            battle.SetPlayerTwoSelections(CreatePlayerTwoSelections());
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
        }

        [UnitTest]
        public void BattleStateShouldBePlayerTwoRockPaperScissors()
        {
			First();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(CreatePlayerOneSelections());
            battle.SetPlayerTwoSelections(CreatePlayerTwoSelections());
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Rock);
            Expect.IsTrue(battle.State == BattleState.PendingPlayerTwoRockPaperScissors);
        }

        [UnitTest]
        public void BattleStateShouldBePlayerOneRockPaperScissors()
        {
			First();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(CreatePlayerOneSelections());
            battle.SetPlayerTwoSelections(CreatePlayerTwoSelections());
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            Expect.IsTrue(battle.State == BattleState.PendingPlayerOneRockPaperScissors);
        }

        [UnitTest]
        public void RockPaperScissorsWinnerShouldBePlayerOne()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);
            battle.SetPlayerTwoSelections(playerTwoSelections);
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Paper);
            Player one = battle.PlayerOne;
            Expect.IsTrue(battle.RockPaperScissorsWinner.Equals(one));
			After();
        }

        [UnitTest]
        public void RockPaperScissorsWinnerShouldBePlayerTwo()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);
            battle.SetPlayerTwoSelections(playerTwoSelections);
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Scissors);
            Player two = battle.PlayerTwo;
            Expect.IsTrue(battle.RockPaperScissorsWinner.Equals(two));
			After();
        }

        [UnitTest]
        public void BattleStateShouldBePendingRockPaperScissorsAfterTie()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);
            battle.SetPlayerTwoSelections(playerTwoSelections);
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Rock);

            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            Expect.IsNull(battle.RockPaperScissorsWinner, "Rock paper scissors winner should be null");
            Expect.IsNull(battle.Field, "Battle.Field should be null");
			After();
        }

        //PendingDefender
        [UnitTest]
        public void BattleStateShouldBePendingDefender()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);
            battle.SetPlayerTwoSelections(playerTwoSelections);
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Paper);
            Player one = battle.PlayerOne;
            Expect.IsTrue(battle.RockPaperScissorsWinner.Equals(one));
            Expect.IsTrue(battle.State == BattleState.PendingTurn);
            
            AttackOptions attack = new AttackOptions();
            attack.Character = playerOneSelections.Characters[0];
            attack.Weapon = playerOneSelections.Weapons[0];
            //attack.Spell = playerOneSelections.Spells[0]; // this should cause an error
            //attack.Skill = playerOneSelections.Skills[0]; // this should cause an error also
            battle.Attack(attack);
            Expect.IsTrue(battle.State == BattleState.PendingDefender);
			After();
        }

        [UnitTest]
        public void BattleStateShouldBePendingAttacker()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);
            battle.SetPlayerTwoSelections(playerTwoSelections);
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Paper);
            Player one = battle.PlayerOne;
            Expect.IsTrue(battle.RockPaperScissorsWinner.Equals(one));
            Expect.IsTrue(battle.State == BattleState.PendingTurn);

            DefendOptions defense = new DefendOptions();            
            battle.Defend(defense);

            Expect.IsTrue(battle.State == BattleState.PendingAttacker);
			After();
        }
        
        [UnitTest]
        public void SetPlayerSelectionsShouldSetupPlayerFields()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);

            Expect.IsTrue(playerOneSelections.Characters.Length > 0);
            playerOneSelections.Characters.Each(l =>
            {
                Character check = battle.PlayerOneField.AllCharacters.Where(c => c.Id.Value == l).FirstOrDefault();
                Expect.IsNotNull(check);
            });

            battle.SetPlayerTwoSelections(playerTwoSelections);
            Expect.IsTrue(playerTwoSelections.Characters.Length > 0);
            playerTwoSelections.Characters.Each(l =>
            {
                Character check = battle.PlayerTwoField.AllCharacters.Where(c => c.Id.Value == l).FirstOrDefault();
                Expect.IsNotNull(check);
            });
			After();
        }

        [UnitTest]
        public void BattleStateShouldBePendingTurnAfterAttackDefense()
        {
			First();
            PlayerSelections playerOneSelections = CreatePlayerOneSelections();
            PlayerSelections playerTwoSelections = CreatePlayerTwoSelections();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(playerOneSelections);
            long[] activeIds = battle.MaxActiveCharacters.Value.Times(i =>
            {
                return playerOneSelections.Characters[i];
            });
            battle.SetPlayerOneActiveCharacters(activeIds);

            battle.SetPlayerTwoSelections(playerTwoSelections);
            activeIds = battle.MaxActiveCharacters.Value.Times(i =>
            {
                return playerTwoSelections.Characters[i];
            });
            battle.SetPlayerTwoActiveCharacters(activeIds);

            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Paper);
            Player one = battle.PlayerOne;
            Expect.IsTrue(battle.RockPaperScissorsWinner.Equals(one));
            Expect.IsTrue(battle.State == BattleState.PendingTurn);

            AttackOptions attack = new AttackOptions();
            attack.Character = playerOneSelections.Characters[0];
            attack.Weapon = playerOneSelections.Weapons[0];
            attack.Target = playerTwoSelections.Characters[0];
            battle.Attack(attack);

            DefendOptions defense = new DefendOptions();
            
            battle.Defend(defense);

            Expect.IsTrue(battle.State == BattleState.PendingTurn);
            Expect.IsNotNull(battle.Field);
            Expect.IsTrue(battle.Field.Attacker.Player.Equals(battle.PlayerTwo));
			After();
        }

        [UnitTest]
        public void BattleStateShouldBePendingTurn()
        {
			First();
            Battle battle = StartTestBattle();
            battle.SetBattleType(BattleType.Three);
            battle.SetPlayerOneSelections(CreatePlayerOneSelections());
            battle.SetPlayerTwoSelections(CreatePlayerTwoSelections());
            Expect.IsTrue(battle.State == BattleState.PendingRockPaperScissors);
            battle.SetPlayerTwoRockPaperScissors(RockPaperScissors.Rock);
            battle.SetPlayerOneRockPaperScissors(RockPaperScissors.Paper);
            Player one = battle.PlayerOne;
            Expect.IsTrue(battle.RockPaperScissorsWinner.Equals(one));
            Expect.IsTrue(battle.State == BattleState.PendingTurn);
			After();
        }
        internal static PlayerSelections CreatePlayerOneSelections()
        {
            return CreateTestSelections(GetPlayerOne());
        }
        internal static PlayerSelections CreatePlayerTwoSelections()
        {
            return CreateTestSelections(GetPlayerTwo());
        }

        internal static PlayerSelections CreateTestSelections(Player player)
        {
            Character[] characters = GetTestCharacters(6);
            Weapon[] weapons = GetTestWeapons(2);
            Spell[] spells = GetTestSpells(4);
            Skill[] skills = GetTestSkills(4);
            Equipment[] equipment = GetTestEquipment(4);

            player.Acquire(characters);
            player.Acquire(weapons);
            player.Acquire(spells);
            player.Acquire(skills);
            player.Acquire(equipment);

            PlayerSelections result = new PlayerSelections();
            result.Characters = characters.Select(c => c.Id.Value).ToArray();
            result.Weapons = weapons.Select(w => w.Id.Value).ToArray();
            result.Spells = spells.Select(s => s.Id.Value).ToArray();
            result.Skills = skills.Select(s => s.Id.Value).ToArray();
            result.Equipment = equipment.Select(s => s.Id.Value).ToArray();
            result.Player = player;
            return result;
        }

        [UnitTest]
        public void GetOnePlayerShouldNotDuplicate()
        {
			First();
            string name= "Name_".RandomLetters(4);
            Player one = Player.GetOne(name);
            Player two = Player.GetOne(name);
            Expect.AreEqual(one, two);
			After();
        }
            
        [UnitTest]
        public void PlayerOneAndTwoShouldBeRightAfterBattleStarts()
        {
			First();
            Player one = Player.GetOne("Player_".RandomLetters(4));
            Player two = Player.GetOne("Player_".RandomLetters(4));
            Battle b = Battle.StartNew(one, two);
            Expect.AreEqual(one, b.PlayerOne);
            Expect.AreEqual(two, b.PlayerTwo);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToSetBattleType()
        {
			First();
            Player one = Player.GetOne("Player_".RandomLetters(4));
            Player two = Player.GetOne("Player_".RandomLetters(4));
            Battle b = Battle.StartNew(one, two);
            b.SetBattleType(BattleType.Three);
            Expect.AreEqual((int)BattleType.Three, b.MaxActiveCharacters.Value);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToCreateCharacter()
        {
			First();
            Character c = Character.Create("Test Characer_".RandomLetters(4), 
                10, 10, 10, 10, 10, 100, Elements.Fire);

            Expect.IsNotNull(c);
            Expect.IsNotNull(c.Id);
            Expect.IsGreaterThan(c.Id.Value, 0);
            Character check = Character.OneWhere(f => f.Id == c.Id);
            Expect.AreEqual(c.Name, check.Name);
			After();
        }
        
        [UnitTest]
        public void ShouldBeAbleToCreateWeapon()
        {
			First();
            Weapon w = Weapon.Create("Test Weapon_".RandomLetters(4), 10, Elements.Air);

            Expect.IsNotNull(w);
            Expect.IsNotNull(w.Id);
            Expect.IsGreaterThan(w.Id.Value, 0);
            Weapon check = Weapon.OneWhere(f => f.Id == w.Id);
            Expect.AreEqual(w.Name, check.Name);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToCreateSpell()
        {
			First();
            Spell s = Spell.Create("Test spell_".RandomLetters(4), 10, Elements.Water);

            Expect.IsNotNull(s);
            Expect.IsNotNull(s.Id);
            Expect.IsGreaterThan(s.Id.Value, 0);
            Spell check = Spell.OneWhere(f => f.Id == s.Id);
            Expect.AreEqual(s.Name, check.Name);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToCreateSkill()
        {
			First();
            Skill s = Skill.Create("Test skill_".RandomLetters(4), 10);

            Expect.IsNotNull(s);
            Expect.IsNotNull(s.Id);
            Expect.IsGreaterThan(s.Id.Value, 0);
            Skill check = Skill.OneWhere(f => f.Id == s.Id);
            Expect.AreEqual(s.Name, check.Name);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToCreateEffects()
        {
			First();
            Dictionary<CharacterAttributes, int> effectDictionary = new Dictionary<CharacterAttributes,int>();
            effectDictionary[CharacterAttributes.Strength] = -3;
            effectDictionary[CharacterAttributes.Magic] = +6;
            effectDictionary[CharacterAttributes.Acuracy] = +2;

            Effect[] ef = Effect.FromDictionary(effectDictionary);
            Expect.AreEqual(3, ef.Length);

            Effect check = ef.Where(e => e.Attribute == CharacterAttributes.Strength.ToString()).FirstOrDefault();
            Expect.IsNotNull(check);
            Expect.AreEqual(-3, check.Value);

            check = ef.Where(e => e.Attribute == CharacterAttributes.Magic.ToString()).FirstOrDefault();
            Expect.IsNotNull(check);
            Expect.AreEqual(+6, check.Value);

            check = ef.Where(e => e.Attribute == CharacterAttributes.Acuracy.ToString()).FirstOrDefault();
            Expect.IsNotNull(check);
            Expect.AreEqual(+2, check.Value);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToCreateEquipment()
        {
			First();
            Dictionary<CharacterAttributes, int> effects = new Dictionary<CharacterAttributes, int>();
            effects[CharacterAttributes.Magic] = +8;
            effects[CharacterAttributes.Speed] = -1;
            Effect[] ef = Effect.FromDictionary(effects);
            Equipment eq = Equipment.Create("Test equipment_".RandomLetters(4), ef);
            Expect.AreEqual(2, eq.EffectsByEquipmentId.Count);
            ef.Each(eff =>
            {
                Expect.IsTrue(eq.EffectsByEquipmentId.Contains(eff));
            });
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToSetPlayerOneCharacterSelections()
        {
			First();
            Battle battle = StartTestBattle();
            
            Character[] oneCharacters = GetTestCharacters(6);
            long[] charIds = oneCharacters.Select(ch => ch.Id.Value).ToArray();
            
            PlayerSelections oneSelections = new PlayerSelections();
            oneSelections.Characters = charIds;
            oneSelections.SuppressValidate = false;
            battle.SetPlayerOneSelections(oneSelections);

            PlayerField oneField = battle.PlayerOneField;
            Expect.AreEqual(oneCharacters.Length, oneField.AllCharacters.Length);

            oneCharacters.Each(c =>
            {
                Expect.IsTrue(oneField.AllCharacters.Contains(c));
            });
			After();
        }

        class TestPlayer : Player
        {
            public bool PrepareForBattleCalled { get; set; }
            public override void PrepareForBattle(Battle battle)
            {
                this.PrepareForBattleCalled = true;
            }
        }

        [UnitTest]
        public void StartNewBattleShouldCallPrepareForBattle()
        {
			First();
            TestPlayer one = new TestPlayer();
            TestPlayer two = new TestPlayer();
            Expect.IsFalse(one.PrepareForBattleCalled, "P1 PrepareForBattle was true and shouldn't have been");
            Expect.IsFalse(two.PrepareForBattleCalled, "P2 PrepareForBattle was true and shouldn't have been");
            Battle testBattle = Battle.StartNew(one, two);
            Expect.IsTrue(one.PrepareForBattleCalled, "P1 PrepareForBattle was not called");
            Expect.IsTrue(two.PrepareForBattleCalled, "P2 PrepareForBattle was not called");
			After();
        }

        Player _testPlayer;
        public void EraseTestPlayersExistence()
        {
            _testPlayer.Characters.BackwardsEach(ch =>
            {
                _testPlayer.Characters.Remove(ch);
            });

            _testPlayer.Weapons.BackwardsEach(w =>
            {
                _testPlayer.Weapons.Remove(w);
            });

            _testPlayer.Spells.BackwardsEach(sp =>
            {
                _testPlayer.Spells.Remove(sp);
            });

            _testPlayer.Skills.BackwardsEach(sk =>
            {
                _testPlayer.Skills.Remove(sk);
            });

            _testPlayer.Equipments.BackwardsEach(eq =>
            {
                _testPlayer.Equipments.Remove(eq);
            });

            _testPlayer.Delete();
        }

        [UnitTest]
        public void ShouldBeAbleToAcquireCharacter()
        {
			First();
            Player test = Player.GetOne("Acquiring Character Player");
            _testPlayer = test;
            Character monkey = Character.Create("Monkey", 8, 9, 4, 6, 93, 175, Elements.Earth);
            
            Expect.IsFalse(test.Has(monkey), "Expected test character not to have Monkey");
            test.Acquire(monkey);
            Expect.IsTrue(test.Has(monkey));

            Player reloaded = Player.OneWhere(c => c.Id == test.Id.Value);
            Expect.IsTrue(reloaded.Has(monkey));
			EraseTestPlayersExistence();
        }

        [UnitTest]
        public void ShouldBeAbleToAcquireSpell()
        {
			First();
            Player test = Player.GetOne("Acquiring Spell Player");
            _testPlayer = test;
            Spell fireBall = Spell.Create("Fire Ball", 8, Elements.Fire);

            Expect.IsFalse(test.Has(fireBall), "Expected test character not to have Fire Ball");
            test.Acquire(fireBall);
            Expect.IsTrue(test.Has(fireBall));

            Player reloaded = Player.OneWhere(c => c.Id == test.Id.Value);
            Expect.IsTrue(reloaded.Has(fireBall));
			EraseTestPlayersExistence();
        }

        [UnitTest]
        public void ShouldBeAbleToAcquireWeapon()
        {
			First();
            Player test = Player.GetOne("Acquiring Weapon Player");
            _testPlayer = test;
            Weapon giantHammer = Weapon.Create("Giant Hammer", 8, Elements.Fire);

            Expect.IsFalse(test.Has(giantHammer), "Expected test character not to have Giant Hammer");
            test.Acquire(giantHammer);
            Expect.IsTrue(test.Has(giantHammer));

            Player reloaded = Player.OneWhere(c => c.Id == test.Id.Value);
            Expect.IsTrue(reloaded.Has(giantHammer));
			EraseTestPlayersExistence();
        }

        [UnitTest]
        public void ShouldBeAbleToAcquireSkill()
        {
			First();
            Player test = Player.GetOne("Acquiring Skill Player");
            _testPlayer = test;
            Skill facePunch = Skill.Create("Face Punch", 3);

            Expect.IsFalse(test.Has(facePunch), "Expected test character not to have Face Punch");
            test.Acquire(facePunch);
            Expect.IsTrue(test.Has(facePunch));

            Player reloaded = Player.OneWhere(c => c.Id == test.Id.Value);
            Expect.IsTrue(reloaded.Has(facePunch));
			EraseTestPlayersExistence();
        }

        [UnitTest]
        public void ShouldBeAbleToAcquireEquipment()
        {
			First();
            Player test = Player.GetOne("Acquiring Equipment Player");
            _testPlayer = test;
            Dictionary<CharacterAttributes, int> effects = new Dictionary<CharacterAttributes, int>();
            effects[CharacterAttributes.Magic] = 4;
            effects[CharacterAttributes.Speed] = -1;

            Equipment tinFoilHat = Equipment.Create("Tin Foil Hat", effects);

            Expect.IsFalse(test.Has(tinFoilHat), "Expected test character not to have Monkey");
            test.Acquire(tinFoilHat);
            Expect.IsTrue(test.Has(tinFoilHat));

            Player reloaded = Player.OneWhere(c => c.Id == test.Id.Value);
            Expect.IsTrue(reloaded.Has(tinFoilHat));
			EraseTestPlayersExistence();
        }

        [UnitTest]
        public void EquipmentShouldHaveEffects()
        {
			First();
            Dictionary<CharacterAttributes, int> effects = new Dictionary<CharacterAttributes, int>();
            effects[CharacterAttributes.Defense] = +3;
            effects[CharacterAttributes.Magic] = -1;

            Equipment woodShield = Equipment.Create("Wooden Shield", effects, Elements.Earth);
            Effect plusThreeDefense = woodShield.Effects.Where(ef => ef.Attribute.Equals("Defense")).FirstOrDefault();
            Expect.IsNotNull(plusThreeDefense, "Plus 3 defense not found");
            Expect.AreEqual(3, plusThreeDefense.Value);
            Effect minusOneMagic = woodShield.Effects.Where(ef => ef.Attribute.Equals("Magic")).FirstOrDefault();
            Expect.IsNotNull(minusOneMagic, "Minus one magic");
            Expect.AreEqual(-1, minusOneMagic.Value);
        }

        [UnitTest]
        public void PlayerSelectionsValidationTest()
        {
			First();
            Player one = Player.GetOne("Selection Validation Test Player");
            _testPlayer = one;
            Character oldBaldGuy = Character.Create("Old Bald Guy", 3, 2, 1, 1, 79, 50, Elements.Air);

            PlayerSelections selections = new PlayerSelections();
            selections.Characters = new long[] { oldBaldGuy.Id.Value };

            PlayerSelectionsValidation validation = selections.TryValidate();
            Expect.IsFalse(validation.Success);
            Out(validation.Message, ConsoleColor.Cyan);

            selections.Player = one;

            validation = selections.TryValidate();
            Expect.IsFalse(validation.Success);
            Out(validation.Message, ConsoleColor.Cyan);

            one.Acquire(oldBaldGuy);

            validation = selections.TryValidate();
            Expect.IsTrue(validation.Success);
            Out(validation.Message, ConsoleColor.Cyan);

			EraseTestPlayersExistence();
        }

        class TestPlayerSelections: PlayerSelections
        {
            public TestPlayerSelections() { }

            public bool Set { get; set; }

            public bool TryValidateCalled { get; set; }
            public override PlayerSelectionsValidation TryValidate()
            {
                if (Set)
                {
                    TryValidateCalled = true;
                }
                return base.TryValidate();
            }
        }

        [UnitTest]
        public void BattleSetSelectionsShouldCallTryValidate()
        {
			First();
            Battle battle = StartTestBattle();
            TestPlayerSelections oneSelections = new TestPlayerSelections();
            Expect.IsFalse(oneSelections.TryValidateCalled, "TryValidateCalled was already true and it shouldn't have been");
            oneSelections.Set = true;
            battle.SetPlayerOneSelections(oneSelections);
            Expect.IsTrue(oneSelections.TryValidateCalled, "TryValidateCalled was not true");
        }

        [UnitTest]
        public void ShouldBeAbleToSetPlayerTwoCharacterSelections()
        {
			First();
            Character[] twoCharacters = GetTestCharacters(6);
            long[] charIds = twoCharacters.Select(ch => ch.Id.Value).ToArray();

            PlayerSelections twoSelections = new PlayerSelections();
            twoSelections.Characters = charIds;
            
            Battle battle = StartTestBattle();
            battle.SetPlayerTwoSelections(twoSelections);

            PlayerField twoField = battle.PlayerTwoField;
            Expect.AreEqual(twoCharacters.Length, twoField.AllCharacters.Length);

            twoCharacters.Each(c =>
            {
                Expect.IsTrue(twoField.AllCharacters.Contains(c));
            });
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToSetPlayerOneWeaponSelections()
        {
			First();
            Weapon[] weapons = GetTestWeapons(2);
            long[] weaponIds = weapons.Select(w => w.Id.Value).ToArray();

            PlayerSelections selections = new PlayerSelections();
            selections.SuppressValidate = false;
            selections.Weapons = weaponIds;

            Battle battle = StartTestBattle();
            battle.SetPlayerOneSelections(selections);

            PlayerField field = battle.PlayerOneField;
            Expect.IsNotNull(field.Weapons);
            Expect.AreEqual(weapons.Length, field.Weapons.Length);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToSetPlayerTwoWeaponSelections()
        {
			First();
            Weapon[] weapons = GetTestWeapons(2);
            long[] weaponIds = weapons.Select(w => w.Id.Value).ToArray();

            PlayerSelections selections = new PlayerSelections();
            selections.SuppressValidate = false;
            selections.Weapons = weaponIds;

            Battle battle = StartTestBattle();
            battle.SetPlayerTwoSelections(selections);

            PlayerField field = battle.PlayerTwoField;
            Expect.IsNotNull(field.Weapons);
            Expect.AreEqual(weapons.Length, field.Weapons.Length);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToSetPlayerOneSelections()
        {
			First();
            PlayerSelections selections = CreatePlayerOneSelections();//new PlayerSelections { Characters = characters, Weapons = weapons, Spells = spells, Skills = skills, Equipment = equipment };
            long[] characters = selections.Characters;
            long[] weapons = selections.Weapons;
            long[] spells = selections.Spells;
            long[] skills = selections.Skills;
            long[] equipment = selections.Equipment;

            Battle battle = StartTestBattle();
            battle.SetPlayerOneSelections(selections);

            PlayerField field = battle.PlayerOneField;
            ValidateSelections(characters, weapons, spells, skills, equipment, field);
			After();
        }

        [UnitTest]
        public void ShouldBeAbleToSetPlayerTwoSelections()
        {
			First();
            PlayerSelections selections = CreatePlayerTwoSelections();//new PlayerSelections { Characters = characters, Weapons = weapons, Spells = spells, Skills = skills, Equipment = equipment };
            long[] characters = selections.Characters;
            long[] weapons = selections.Weapons;
            long[] spells = selections.Spells;
            long[] skills = selections.Skills;
            long[] equipment = selections.Equipment;
            Battle battle = StartTestBattle();
            battle.SetPlayerTwoSelections(selections);

            PlayerField field = battle.PlayerTwoField;
            ValidateSelections(characters, weapons, spells, skills, equipment, field);
			After();
        }

        private static void ValidateSelections(long[] characters, long[] weapons, long[] spells, long[] skills, long[] equipment, PlayerField field)
        {
            Expect.IsNotNull(field.AllCharacters);
            Expect.IsNotNull(field.Weapons);
            Expect.IsNotNull(field.AllSpells);
            Expect.IsNotNull(field.Skills);
            Expect.IsNotNull(field.AllEquipment);

            Expect.AreEqual(characters.Length, field.AllCharacters.Length);
            Expect.AreEqual(weapons.Length, field.Weapons.Length);
            Expect.AreEqual(spells.Length, field.AllSpells.Length);
            Expect.AreEqual(skills.Length, field.Skills.Length);
            Expect.AreEqual(equipment.Length, field.AllEquipment.Length);

            characters.Each(id =>
            {
                Character check = Character.OneWhere(c => c.Id == id);
                Expect.IsTrue(field.AllCharacters.Contains(check));
            });

            weapons.Each(id =>
            {
                Weapon check = Weapon.OneWhere(c => c.Id == id);
                Expect.IsTrue(field.Weapons.Contains(check));
            });

            spells.Each(id =>
            {
                Spell check = Spell.OneWhere(c => c.Id == id);
                Expect.IsTrue(field.AllSpells.Contains(check));
            });

            skills.Each(id =>
            {
                Skill check = Skill.OneWhere(c => c.Id == id);
                Expect.IsTrue(field.Skills.Contains(check));
            });

            equipment.Each(id =>
            {
                Equipment check = Equipment.OneWhere(c => c.Id == id);
                Expect.IsTrue(field.AllEquipment.Contains(check));
            });
        }

        internal static Battle StartTestBattle()
        {
            Player pOne = GetPlayerOne();
            Player pTwo = GetPlayerTwo();

            Battle battle = Battle.StartNew(pOne, pTwo);
            return battle;
        }

        internal static Player GetPlayerOne()
        {
            return Player.GetOne("Player One");
        }

        internal static Player GetPlayerTwo()
        {
            return Player.GetOne("Player Two");
        }

        static List<Character> _testCharacters;
        private static Character[] GetTestCharacters(int count)
        {
            _testCharacters = Character.Where(c => c.Id != null).ToList();

            Character[] result = new Character[count];
            if (_testCharacters.Count < count)
            {
                for (int i = 0; i < count; i++)
                {
                    result[i] = Character.Create("Test Char ({0})"._Format("".RandomLetters(4)),
                        RandomNumber.Between(1, 10),
                        RandomNumber.Between(1, 10),
                        RandomNumber.Between(1, 10),
                        RandomNumber.Between(1, 10),
                        RandomNumber.Between(85, 100),
                        100,
                        Elements.Water);
                }
            }
            else
            {
                count.Times(i =>
                {
                    result[i] = _testCharacters[i];
                });
            }
            
            return result;
        }

        static List<Weapon> _testWeapons;
        private static Weapon[] GetTestWeapons(int count)
        {
            _testWeapons = Weapon.Where(c => c.Id != null).ToList();

            Weapon[] result = new Weapon[count];
            if (_testWeapons.Count < count)
            {
                count.Times(i =>
                {
                    result[i] = Weapon.Create("Test weapon_".RandomLetters(4), RandomNumber.Between(1, 10), Elements.Earth);
                });
            }
            else
            {
                count.Times(i =>
                {
                    result[i] = _testWeapons[i];
                });
            }
            return result;
        }

        static List<Spell> _testSpells = new List<Spell>();
        private static Spell[] GetTestSpells(int count)
        {
            _testSpells = Spell.Where(c => c.Id != null).ToList();

            Spell[] result = new Spell[count];
            if (_testSpells.Count < count)
            {
                count.Times(i =>
                {
                    result[i] = Spell.Create("Test spell_".RandomLetters(4), RandomNumber.Between(1, 10), Elements.Air);
                });
                _testSpells.AddRange(result);
            }
            else
            {
                count.Times(i =>
                {
                    result[i] = _testSpells[i];
                });
            }
            return result;
        }

        static List<Skill> _testSkills;
        private static Skill[] GetTestSkills(int count)
        {
            _testSkills = Skill.Where(c => c.Id != null).ToList();

            Skill[] result = new Skill[count];
            if (_testSkills.Count < count)
            {
                count.Times(i =>
                {
                    result[i] = Skill.Create("Test skill_".RandomLetters(4), RandomNumber.Between(1, 10));
                });
            }
            else
            {
                count.Times(i =>
                {
                    result[i] = _testSkills[i];
                });
            }
            return result;
        }

        static List<Equipment> _testEquipment;
        private static Equipment[] GetTestEquipment(int count)
        {
            _testEquipment = Equipment.Where(c => c.Id != null).ToList();
            Equipment[] result = new Equipment[count];

            if (_testEquipment.Count < count)
            {
                count.Times(i =>
                {
                    Dictionary<CharacterAttributes, int> effects = new Dictionary<CharacterAttributes, int>();
                    effects[CharacterAttributes.Strength] = +5;
                    effects[CharacterAttributes.Defense] = -2;
                    effects[CharacterAttributes.Speed] = +1;
                    effects[CharacterAttributes.Magic] = +4;
                    effects[CharacterAttributes.Acuracy] = -3;
                    result[i] = Equipment.Create("Test equipment_".RandomLetters(4), effects);
                });
            }
            else
            {
                count.Times(i =>
                {
                    result[i] = _testEquipment[i];
                });
            }
            return result;
        }

        [UnitTest]
        public void OutputContextInfoUsingReflection()
        {
            PropertyInfo prop = typeof(BattleStickersContext).GetProperty("ConnectionName");
            string name = (string)prop.GetValue(null);
            OutLine(name);
        }
    }

}
