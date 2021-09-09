package setsgame

import (
	"testing"
)

func TestCardById7GreenSquiggleSolidSingle(t *testing.T) {
	target := CardById(7)
	expected := Card{Green, Squiggle, Solid, Single}

	if target != expected {
		t.Error()
	}
}

func TestCardById49PurpleOvalLinesSingle(t *testing.T) {
	target := CardById(49)
	expected := Card{Purple, Oval, Lines, Single}

	if target != expected {
		t.Error()
	}
}

func TestCardById54GreenOvalLinesTriple(t *testing.T) {
	target := CardById(54)
	expected := Card{Green, Oval, Lines, Triple}

	if target != expected {
		t.Error()
	}
}

func TestCardById77PurpleOvalEmptyDouble(t *testing.T) {
	target := CardById(77)
	expected := Card{Purple, Oval, Empty, Double}

	if target != expected {
		t.Error()
	}
}

func TestParseCardsShouldFindCard49(t *testing.T) {
	htm := "<div class=\"set-card-td\"><a href=\"javascript:board.cardClicked(1)\" border=\"0\"><img nopin=\"nopin\" class=\"A1\" src=\"/sites/all/modules/setgame_set/assets/images/new/49.png\" name=\"card1\"></a><p class=\"set-inputs\"><input name=\"A1\" type=\"checkbox\" onclick=\"board.count()\"></input></p></div>"
	cards := parseCards(htm)

	if len(cards) != 1 {
		t.Fatalf("Expected to find 1 card, found %d", len(cards))
	}

	target := cards[0]
	expected := Card{Purple, Oval, Lines, Single}

	if target != expected {
		t.Error()
	}
}

func TestParseCardsShouldFind12Cards(t *testing.T) {
	htm := `<td>
	<div class="set-card-td"><a href="javascript:board.cardClicked(1)" border="0"><img nopin="nopin" class="A1" src="/sites/all/modules/setgame_set/assets/images/new/76.png" name="card1"></a><p class="set-inputs"><input name="A1" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(2)" border="0"><img nopin="nopin" class="A2" src="/sites/all/modules/setgame_set/assets/images/new/44.png" name="card2"></a><p class="set-inputs"><input name="A2" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(3)" border="0"><img nopin="nopin" class="A3" src="/sites/all/modules/setgame_set/assets/images/new/3.png" name="card3"></a><p class="set-inputs"><input name="A3" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(4)" border="0"><img nopin="nopin" class="A4" src="/sites/all/modules/setgame_set/assets/images/new/62.png" name="card4"></a><p class="set-inputs"><input name="A4" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(5)" border="0"><img nopin="nopin" class="A5" src="/sites/all/modules/setgame_set/assets/images/new/35.png" name="card5"></a><p class="set-inputs"><input name="A5" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(6)" border="0"><img nopin="nopin" class="A6" src="/sites/all/modules/setgame_set/assets/images/new/45.png" name="card6"></a><p class="set-inputs"><input name="A6" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(7)" border="0"><img nopin="nopin" class="A7" src="/sites/all/modules/setgame_set/assets/images/new/31.png" name="card7"></a><p class="set-inputs"><input name="A7" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(8)" border="0"><img nopin="nopin" class="A8" src="/sites/all/modules/setgame_set/assets/images/new/12.png" name="card8"></a><p class="set-inputs"><input name="A8" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(9)" border="0"><img nopin="nopin" class="A9" src="/sites/all/modules/setgame_set/assets/images/new/67.png" name="card9"></a><p class="set-inputs"><input name="A9" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(10)" border="0"><img nopin="nopin" class="A10" src="/sites/all/modules/setgame_set/assets/images/new/13.png" name="card10"></a><p class="set-inputs"><input name="A10" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(11)" border="0"><img nopin="nopin" class="A11" src="/sites/all/modules/setgame_set/assets/images/new/54.png" name="card11"></a><p class="set-inputs"><input name="A11" type="checkbox" onclick="board.count()"></input></p></div><div class="set-card-td"><a href="javascript:board.cardClicked(12)" border="0"><img nopin="nopin" class="A12" src="/sites/all/modules/setgame_set/assets/images/new/17.png" name="card12"></a><p class="set-inputs"><input name="A12" type="checkbox" onclick="board.count()"></input></p></div>
	</td>`
	cards := parseCards(htm)

	if len(cards) != 12 {
		t.Fatalf("Expected to find 12 card, found %d", len(cards))
	}

	expectedCards := []Card{
		CardById(76),
		CardById(44),
		CardById(3),
		CardById(62),
		CardById(35),
		CardById(45),
		CardById(31),
		CardById(12),
		CardById(67),
		CardById(13),
		CardById(54),
		CardById(17),
	}

	for i, card := range cards {
		if expectedCards[i] != card {
			t.Error()
		}
	}
}
