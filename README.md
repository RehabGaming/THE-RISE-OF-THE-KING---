# משחק שיקום המלך / The Rise Of The King 

"שיקום המלך" הוא משחק ייחודי שבו שחקנים נכנסים לתפקיד המטפל המלכותי, שמטרתו לשקם את המלך לאחר פציעה מיסטית. במשחק יעברו השחקנים בין חדרי הטירה המלכותית, ובכל חדר יתמודדו עם משימות ומיני-משחקים שונים המיועדים לשקם כישורים פיזיים וקוגניטיביים.

<p align="center">
  <img src="https://github.com/RehabGaming/King-s-Rehab-Game/blob/main/Pictures/For%20The%20Whole%20Game.jpg" alt="Rehabilitation of the King" width="350">
</p>

## פלטפורמות
המשחק מיועד לפלטפורמת המחשב עם אפשרות להתקנה על מערכות Windows.

## חברי הצוות
- אליעוז קולני
- אופק מרום
- דניאל כהן-שדה
- אגם חמו
- אפרת הבר
- ניקול

### רכיבים רשמיים
[לצפייה ברכיבים הרשמיים של המשחק](https://github.com/RehabGaming/King-s-Rehab-Game/blob/main/formal-elements.md)

[לצפייה בתרשים זרימה למשחק](https://github.com/RehabGaming/King-s-Rehab-Game/blob/main/FlowChart%20-%20picture.png)

[למשחק אונליין!](https://rehabgaming1.itch.io/the-rise-of-the-king)

[לצפייה בסרטון כניסה למשחק](https://drive.google.com/file/d/1QLeyRdeHDK9wQDOmVAq6LDONfyg6Mvgo/view?usp=sharing)


---

## מדריך שימוש

### פונקציות מיוחדות וסקריפטים מרכזיים

#### SingletonManager
**תיאור:**  
מחלקה זו אחראית לניהול אינסטנס יחיד (Singleton) של GameManager בכל סצנה. המחלקה מוודאת שקיימת רק אינסטנס אחד שמתאים לסצנה הנוכחית, ומבצעת אתחול של רכיבים קריטיים כמו SceneManagement ו-ExplanationManager.

**מאפיינים עיקריים:**
- **Instance:** מבטיח גישה לאינסטנס היחיד של המחלקה.
- **InitializeComponents():** מוודא שרכיבי הניהול החיוניים מחוברים או נוצרים במקרה הצורך.
- **Awake():** מוודא התאמה לסצנה הנוכחית ומשמיד אינסטנסים שאינם רלוונטיים.

[לצפייה בקוד SingletonManager המלא](https://github.com/RehabGaming/THE-RISE-OF-THE-KING---/blob/main/Assets/Scripts/GlobalScripts/SingletonManager.cs)


---

#### ExplanationManager
**תיאור:**  
מחלקה זו אחראית על ניהול והצגת השקפים המסבירים (explanation slides) את מהלך המשחק. המחלקה מטפלת במעבר בין השקפים, דילוג עליהם, וסיום ההסבר תוך אפשרות לעבור לסצנה אחרת.

**מאפיינים עיקריים:**
- **ShowExplanation():** מתחיל את ההסבר על ידי הצגת השקף הראשון והגדרת התנאים ההתחלתיים.
- **NextSlide():** עובר לשקף הבא או מסיים את ההסבר אם זה היה השקף האחרון.
- **SkipExplanation():** מדלג על כל השקפים הנותרים ומסיים את ההסבר באופן מיידי.
- **EndExplanation():** מסיים את ההסבר, מחביא את כל השקפים, ועובר לסצנה המוגדרת אם היא קיימת.
- **UpdateSlideVisibility():** מעדכן את השקפים כך שרק השקף הנוכחי יוצג.
- **UpdateExplanationSlides():** מעדכן את מערך השקפים לפי השקפים הנמצאים בסצנה הנוכחית.

[לצפייה בקוד ExplanationManager המלא](https://github.com/RehabGaming/THE-RISE-OF-THE-KING---/blob/main/Assets/Scripts/GlobalScripts/ExplanationManager.cs)

---

#### SceneManagement
**תיאור:**  
מחלקה זו אחראית לניהול המעבר בין סצנות במשחק, כולל טעינת שלבים, מעבר בין רמות, וטיפול בהשלמת שלבים.

**מאפיינים עיקריים:**
- **LoadLevel(int levelIndex):** טוען שלב לפי אינדקס מהרשימה שהוגדרה.
- **CompleteLevel():** מסמן את השלב הנוכחי כהושלם ומתחיל מעבר לשלב הבא.
- **TransitionToNextLevel(int levelIndex):** מנהל עיכוב זמן לפני טעינת השלב הבא.
- **OnSceneLoaded(Scene scene, LoadSceneMode mode):** מטפל בפעולות הנדרשות לאחר טעינת סצנה, כגון עדכון השקפים המסבירים.
- **OnEnable() / OnDisable():** מנהל מנויים לאירועים של טעינת סצנות.

[לצפייה בקוד SceneManagement המלא](https://github.com/RehabGaming/THE-RISE-OF-THE-KING---/blob/main/Assets/Scripts/GlobalScripts/SceneManagement.cs)

---

## חוקים ותהליכים
- **התחלה**: המשחק מתחיל בסרטון פתיחה אשר מציג את מצב הממלכה והצורך של המלך בעזרת השחקן.
- **ליבה**: השחקנים יחלו במשחק בעל שלבים ומשימות שונות כמו מיון חפצים, מעבר במבוך והגנה על הממלכה.
- **סיום**: בעת השלמת המשימות יוצג טקס חזרתו של המלך כשהוא מאושר ומודה לשחקן.

---

## סקר שוק
בחינת משחקים דומים העלתה כי "שיקום המלך" מייחד את עצמו בשילוב של עלילה מרתקת ומשימות ריפוי קוגניטיביות. כמו כן, המשחק מעמיק יותר באספקטים השיקומיים לעומת מתחריו.

---

## התמקדות ייחודית
עלילת המשחק והמשימות המיוחדות מציעות חוויה שאין במשחקים אחרים, על ידי שילוב של חוויות חושיות ואינטלקטואליות שמאתגרות את השחקן לחשוב ולפעול תוך כדי למידה והנאה.



