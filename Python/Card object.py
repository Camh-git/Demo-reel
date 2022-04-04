class Card():
    def __init__(self,Title,Line_1,Line_2,Line_3,Line_4):
        self.Title = Title
        self.Line_1 = Line_1
        self.Line_2 = Line_2
        self.Line_3 = Line_3
        self.Line_4 = Line_4

card_1 = Card('Card 1','1,2,3','3,4,5','7,8,9','10,11,12')
print(card_1.Title)
print(card_1.Line_1)
print(card_1.Line_2)
print(card_1.Line_3)
print(card_1.Line_4)
