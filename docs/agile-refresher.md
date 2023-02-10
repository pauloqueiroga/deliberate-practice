# Agile Refresher

This is a compilation of thoughts and observations, not a course or a description of Agile or any of the specific Agile methodologies.

## Waterfall and Agile are two ends of a Spectrum, not two buckets

People like to pretend or generalize that something is either Agile or Waterfall. In my opinion, that's a misuse of both terms. Firstly, because *proper* Waterfall is extremely old, was never widely adopted, and precedes the first mentions of "Agile" by many years. When the Agile Manifesto came to be, the term "waterfall" was already being used to describe something different from that original and limited-in-adoption idea.

Steve McConnell in his ["More Effective Agile: A Roadmap for Software Leaders"](https://www.educative.io/courses/more-effective-agile-a-roadmap-for-software-leaders) highlights some of the most significant contrasts between *Sequential Development* and Agile (**emphasis** added by me):

|Sequential Development|Agile Development|
|---|---|
|Long release cycles |Short release cycles|
|Most end-to-end development work performed in large batches across long release cycles|Most end-to-end development work performed in small batches within short release cycles|
|Detailed up-front planning|**High-level up-front planning** with just-in-time detailed planning|
|Detailed up-front requirements|High-level up-front requirements with **just-in-time detailed requirements**|
|Up-front design|**Emergent design**|
|Test at the end, often as separate activity|Continuous, automated testing, integrated into development|
|Infrequent structured collaboration|Frequent **structured collaboration**|
|Overall approach is idealistic, prearranged, and control-oriented|Overall approach is empirical, responsive, and **improvement-oriented**|

My most successful experiences with Agile adoption by very different teams in distinct industries had several of those characteristics in common. Interestingly but not really too surprising, these different cases also shared some of the challenges, pitfalls and misconceptions.

Almost everyone have their eyes on the short cycles and incremental delivery of value. So I'll skip that part. Another unanimity that can be skipped is that development is not complete without continuous and automated testing as part of it and not as a separate concern. Period.

A lot of individuals read expressions such as "just-in-time" or "as little as possible" and immediately assume they mean nothing or close to nothing regarding structure, requirements, planning and forecasting. This has been the most common threat to the success of adoption that I've seen. It is no accident that Agile ideals themselves have evolved in the past twenty years and cleared out some of those initial misconceptions.

The bottom line is that both Sequential and Agile aim at achieving high-quality requirements; structured collaboration; built-in verification and acceptance gates; useful and well-applied management; etc. The successful application of Agile principles are strongly based on applying the principles and ideals that are useful for the specific cases, as well as decidedly not adopting what doesn't make sense, but being intentional and objective about both. Then, **INSPECT AND ADAPT**.

## Scrum, Scrum-but, etc

Scrum is by far the most common Agile approach, as measured by many different ways. Being the most adopted means there's more results to learn from, literature and references to support, more training, more trained professionals, more familiarity overall. That popularity actually feeds more adoption, and the snowball grows stronger.

Scrum prescribes rituals, roles, artifacts and rules in a very straight-forward way. See [The Scrum Guide](https://scrumguides.org/) for detailed but succinct information.

Why are there so many war stories about failed scrum, though?

Since scrum is so concise and straight-forward, there's very little to be cut out of it, and most failed implementations of scrum have in common the fact that something didn't get implemented. For example, I've joined a team who did "Refinement" meetings always before sprint planning, and that time was used for each individual to learn and discuss the stories that were already assigned to them previously by the "Product Owner" to be tackled in the upcoming sprint. In other words, they had recurring meetings named after each one of the Scrum's prescribed events, but they didn't serve the purpose or followed any of the recommendations.

This shall not be misunderstood or misinterpreted as a consequence of inspection and adaptation. When you adopt scrum, and with time and as a result of actual transparency and inspection your process evolves to adapt to your circumstances, you might end up cutting or replacing some aspect of it. The examples given earlier on scrum failures stem from these cuts happening before any chance for transparency and inspection is given.

When in doubt, or when starting an Agile implementation from the beginning, you're much more equipped to succeed if you start with a complete and honest implementation of Scrum's not leaving out any of its roles, rituals, artifacts or rules.

## Agile and Requirements

Poorly described, badly prioritized or inexistent requirements are such a commonly referred source of problems for software engineers. And that's been like that forever. Maybe because of that, or for any other reasons, I've seen over the years too many managers and leaders skipping to the most absurd conclusion of all, as soon as they read the first three or four words of any Agile description: "We need to reduce or eliminate those pesky requirements!"

That misconception might have some influence on how often the Product Owner role is incomplete, insufficient, absent, or spread too thin.

Often, the shortcomings of the role are a fruit of the business not fully supporting (maybe for not fully understanding) how serious the work of the Product Owner should be taken, and how vitally important is to have high-quality requirements. Training and empowerment can make a huge positive difference. The Product Owner needs to be more than just a domain expert, they need to possess and practice their technical requirements skill and have the backing of the leadership to make decisions.

In Scrum, the set of requirements make up the product backlog. High-quality requirements are at the same time a product of and reason for a healthy backlog. Thus, backlog refinement is a continuous effort. If you drop the ball on refinement, the team will end up not having a healthy backlog from which to pull high-quality requirements, and will fall ill with working on poorly described tasks, producing low quality designs and code that don't fulfill the business needs, and so on.
