#Soccer Rank Calculator 
######C# command line application that calculates the rankings for a soccer tournament
----

### **Scoring**

1. The winner of a match receives 3 tournament points while the loser receives 0.
2. In the event of a match draw, both teams receive 1 Tournament point.
3. Teams should be ordered first by rank and then by alphabetical order
    - If two teams are tied for second place, they will appear in alphabetical order with the same rank
4. Teams tied for rank should offset the following rank
    - If two teams are tied for second place, the next ranking after second should be fourth.

--------

* ##### **Input**: Text File with below format

        Falcons 3, Snakes 0
        Diamonds 2, Red Pandas 3
        Gophers 2, Tigers 2
        Lions 1, Bears 2
        Falcons 2, Bears 4
        Red Pandas 1, Snakes 3
        Diamonds 3, Gophers 3
        Tigers 3, Lions 2

* ##### **Output**: Text File with below format
  
        1. Bears 6
        2. Tigers 4
        3. Falcons 3
        4. Red Pandas 3
        5. Snakes 3
        6. Gophers 2
        7. Diamonds 1
        8. Lions 0

----------

##### **Instructions**:

* SoccerRankCalculator.exe and input file *[2015-Matches.txt]* are located bin/Debug Folder
* Please have SoccerRankCalculator.exe and input file *[2015-Matches.txt]* in one folder
* Run .exe file followed by input file in Command Prompt
* Application generates output file *[2015-Ranking.txt]* with results
* Eg: C:/>SoccerRankCalculator.exe 2015-Matches.txt



