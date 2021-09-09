package setsgame

type Color int

const (
	Red Color = iota
	Purple
	Green
	colorCount
)

type Shape int

const (
	Squiggle Shape = iota
	Diamond
	Oval
	shapeCount
)

type Fill int

const (
	Solid Fill = iota
	Lines
	Empty
	fillCount
)

type Size int

const (
	Single Size = iota
	Double
	Triple
	sizeCount
)
