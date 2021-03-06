# UnlockCricketAchievements
A problem where runs have to be divided between batsmen based on the rules of cricket and constraints provided

Unlock Cricket Landmarks

Consider a cricket match where a team is chasing a target and 2 batsmen are playing. It is a given that these 2 batsmen chase the target to win the match, without loss of any more wickets.

Example, Target is 230 runs. Current score of the team is 190. So, there is 40 more runs to be taken.

The 2 batsmen are A and B. A has currently scored and is batting at 60. B has currently scored and is batting at 40. The above given A’s and B’s score are when the team score is 190 and 40 more runs to be chased.

Our objective is to split the remaining runs to be scored (in this case 40) between the batsmen so that their personal landmarks are reached. Landmarks are 50,100,150,200... etc.,

So, in this case, A needs 40 runs to get to his next landmark (100) and B needs 10 runs to reach his next landmark (50). Since B needs lesser runs to achieve his landmark, precedence is given to him, and he gets 10 runs to his name. Of the remaining 30 runs, neither A nor B can reach their landmarks, so the remaining runs are equally split between them.

So, the output would be the final scores of the batsmen, in this case: A – 75 (60+ 15) and B – 65 (40 + 10 + 15).

If the remaining number of runs left was an odd number, then after the equal split, one run would be added to the batsman having the higher score. So, in the above example, A would now have 76 runs (60+16) and B would have 65 runs (40+10+15). If both batsman have the same score, then the 1 extra run will be given to the first batsman (A).

If, for example A’s score was 70 initially (instead of 60), then after 10 runs was allocated to B and 30 more runs were required to achieve the target, those 30 runs should be allocated to A so that he reaches his landmark of 100.

So, the output would be the final scores of the batsmen, in this case: A – 100 (70+ 30) and B – 50 (40+10).

If, in case, equal number of runs need to be split between both, like the below example.
Target:200
Current Score:160
Remaining:40
A:60
B:10
In this case, both need all the remaining 40 runs to achieve their landmarks, but since A’s landmark is higher, he gets the score.
A:100 (60+40)
B:10

If, in case both need same amount of score to reach the same landmark, A gets precedence.
Target:200
Current Score:190
Remaining:10
A:40
B:40
Now, both need 10 runs to achieve the same landmark. In this case, the 10 runs are allocated to A
A:50
B:40

If in case, the target is large enough to span multiple landmarks for the batsmen, then after the initial allocation to the next possible landmark as explained above, 50 runs are allocated as sets to the batsmen based on the higher landmark and precedence of A (as explained above)
Example
Target:300
Current Score:120
Remaining:180
A:90
B:30
In this case, initially A gets 10 runs and then B gets 20 runs. Of the remaining 150 runs, 1st 50 is given to A because of his higher landmark (150). Next 50 to B. The remaining 50 is allocated back to A for his higher landmark (200)
So, the final scores would be
A: 200 (90+10+50+50)
B: 100(30+20+50)

Sample Input - 4 positive non-decimal integers line by line. 1 -> target, 2-> current score, 3-> Batsman A score, 4-> Batman B score
250
130
40
20
Sample Output - 2 positive non-decimal integers line by line. 1-> A score, 2-> B score
115
65




