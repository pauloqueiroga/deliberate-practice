package main

type event struct {
	source1  string
	source2  string
	source3  string
	outcome  string
	treeNode *node
}

type node struct {
	id      string
	company string
	stage   string
	nodes   []*node
	visited bool
	weight  int
	outcome string
}
