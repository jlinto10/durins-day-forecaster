# Durin's Day Forecaster

An extremely useful tool that will predict Durin's day this year (or any year).

It turns out that Tolkien never created a dwarvish calendar. However, we do know that the first day of winter according to the dwarves is November 1st. We also know that it's the last moon of autumn where the sun and the moon can both be seen in the sky. Unfortunately, calculating the latter can be very difficult to predict so most Tolkien fans settle for the last new moon of Autumn (dwarvish Autumn that is).

### Usage

    // Date of durins day for given year :
    
    var durinsDay = new DurinsDayCalculator().GetDurinsDay(2016);
    
    // Days until the next durin's day :
    
    var daysUntilDurinsDay = new DurinsDayCalculator().DaysUntilDurinsDay();

In 2014, the following author calculated Ocotober 24. I ran that year through my tool and got the same output. So I'm assuming that with the logic stated above my calculator is fairly accurate, or accurate enough.

http://askmiddlearth.tumblr.com/post/73200106670/how-to-predict-durins-day