from unittest import TestCase
import Snakes_and_ladders_no_UI

#NOTE: This is for testing the non-autoplaying version of snakes and ladders, it
#should work on both, but will produce lots of excess output as the game plays

class ArrayTest(TestCase):
    """Tests for the array"""

    def setUp(self):
        print("hello")

    def tearDown(self):
        print("hello")

    def TestRollNot0(self):
        x = Roll()
        self.AssertNotEqual(x,0)

    def TestRollLimit(self):
        """Roll the dice 1000 times, see if we go over the limit"""
        top = 0
        I = 0
        while I < 999:
           X = Roll()
           I+=1
           if X > top:
               top = X
        self.AssertTrue(top < 7)
        
    def TestRollMin(self):
        """Roll the dice 1000 times, see if we go under the miniumum"""
        low = 6
        I = 0
        while I < 999:
           X = Roll()
           I+=1
           if X < low:
               low = X  
        self.AssertTrue(low > 0)

    def TestSetup(self):
        subject = Setup_game()
        self.AssertEqual(self.subject.max_pos,100)
        self.AssertEqual(len(self.subject.Ladders),6)
        self.AssertEqual(len(self.subject.Snakes),6)
        
    def TestLadders(self):
        """This is seprate from TestSetup to help identify why the test failed if the dev moves any ladders"""
        subject = Setup_game()
        self.AssertEqual(Self.Subject.Ladders[0].Entrance = 8)
        self.AssertEqual(Self.Subject.Ladders[2].Entrance = 40)
        self.AssertEqual(Self.Subject.Ladders[5].Entrance = 74)
        self.AssertEqual(Self.Subject.Ladders[0].Exit = 20)
        self.AssertEqual(Self.Subject.Ladders[3].Exit = 73)
        self.AssertEqual(Self.Subject.Ladders[5].Exit = 82)

    def TestSnakes(self):
        """This is seprate from TestSetup to help identify why the test failed if the dev moves any snakes"""
        subject = Setup_game()
        self.AssertEqual(Self.Subject.Snakes[0].Entrance = 43)
        self.AssertEqual(Self.Subject.Snakes[2].Entrance = 13)
        self.AssertEqual(Self.Subject.Snakes[5].Entrance = 98)
        self.AssertEqual(Self.Subject.Snakes[0].Exit = 12)
        self.AssertEqual(Self.Subject.Snakes[3].Exit = 25)
        self.AssertEqual(Self.Subject.Snakes[5].Exit = 20)
