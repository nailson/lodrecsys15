# LOD-RecSys 2015 : Call for Challenge: 2nd Linked Open Data-enabled Recommender Systems Challenge

Challenge Website: http://sisinflab.poliba.it/events/lod-recsys-challenge-2015

## MOTIVATION AND OBJECTIVES
People generally need more and more advanced tools that go beyond those implementing the canonical search paradigm for seeking relevant information. A new search paradigm is emerging, where the user's perspective is completely reversed: from finding to being found.
Recommender systems may help to support this new perspective, because they have the effect of pushing relevant objects, selected from a large space of possible options, to potentially interested users. To achieve this result, recommendation techniques generally rely on data referring to three kinds of objects: users, items, and their relations.
Recent developments in the Semantic Web community offer novel strategies to represent data about users, items and their relations that might improve the current state of the art of recommender systems, in order to move towards a new generation of recommender systems which fully understand the items they deal with.
More and more semantic data are published following the Linked Data principles, that enable links to be set up between objects in different data sources, by connecting information in a single global data space: the Web of Data. Today, the Web of Data includes different types of knowledge represented in a homogeneous form: sedimentary one (encyclopedic, cultural, linguistic, common-sense) and real-time one (news, data streams, ...). These data might be useful to interlink diverse information about users, items, and their relations and implement reasoning mechanisms that can support and improve the recommendation process.
The primary goal of this challenge is twofold. On the one hand, we want to enforce the link between the Semantic Web and the Recommender Systems communities. On the other hand, we aim to showcase how Linked Open Data and semantic technologies can boost the creation of a new breed of knowledge-enabled and content-based recommender systems.

## TARGET AUDIENCE
The target audience is all of those communities, both academic and industrial, which are interested in personalized information access with a particular emphasis on Linked Open Data.
During the last ACM RecSys conference the vast majority of participants were from industry. This is evidence of the actual interest of recommender systems for industrial applications ready to be released in the market.

## DATA
We collected data from Facebook profiles about three distinct domains: movies, books and musical artists. After a process of anonymization we then reconciled the data with DBpedia entities. This data will be made available to train the recommendation algorithms. In order to emphasize the usefulness of content-based data, only "cold users" will be available in the dataset.

## TASKS
- Task 1: Top-N recommendations from unary user feedback -
This task deals with the top-N recommendation problem, in which a system is requested to find and recommend a limited set of N items that best match a user profile, instead of correctly predicting the ratings for all available items. In order to favour the proposal of content-based, LOD-enabled recommendation approaches, and limit the use of collaborative filtering approaches, this task aims to generate ranked lists of items for which only unary feedback information (LIKE) is provided. For this task, we will concentrate only on the movie domain.
