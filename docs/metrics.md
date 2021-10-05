# Metrics

One way to come up with useful metrics is to loosely get inspired by the simple and straight-forward methodology of Goal-Question-Metric. You start with a list of goals to be achieved, then you devise questions that would help measure over time how close or far you are from each goal, and if you are moving in the desired direction. Then you devise metrics that would answer the questions.

This document lists a few examples of goals, possible questions associated with those goals, and metrics to help on answering the questions.

## Improve adoption and quality of peer reviews of source code

### Are the development teams understanding better the importance of reviews?

Metrics:

- Number of pull requests not associated to build validation
- Number of pull requests not associated to user stories or bugs
- Bugs marked as resolved or closed while pull request was still pending
- User stories marked as resolved or closed while pull request was still pending
- Number of comments added on someone else's pull requests
- Number of approval votes on someone else's pull requests

### What is still being detected by static analysis of source code?

Metrics:

- % of build pipelines that use static analysis
- Number of Blocker issues found by static analysis
- Number of Critical issues found by static analysis
- Number of Major issues found by static analysis

## Improve estimates for software development work (pre-release)

### How effective is sprint planning?

Metrics:

- Number of story points planned for sprint
- Number of story points completed per sprint
- Number of story points added after sprint planning

### When do we think the backlog will be completed?

Metrics:

- Velocity
- Burn-down
- Cycle Time
- Lead Time

### How effective is backlog refining?

Metrics:

- Number of story points recently added to backlog
- Number of user stories without valid acceptance criteria
- Number of user stories without story points

## Decrease the cost of manual non-QA work by QA engineers

### How much time do QA engineers spend installing and configuring QA environments?

Metrics:

- Total actual effort of tasks tagged as qa-deploy
- Number of distinct individuals assigned to tasks tagged as qa-deploy
