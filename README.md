`אופן השימוש`:

דף הבית – נפתח מיד עם טעינת האתר:
![image](https://github.com/shilat-mori/Hadasim0.4/assets/149057922/c476f703-9691-4c3f-863e-1c50921c0ca3)




פרטי פציינטים – ניתן לנתב ע"י לחיצה על השדה Patients בתפריט למעלה.
![image](https://github.com/shilat-mori/Hadasim0.4/assets/149057922/e0a9bb91-bb05-481c-af58-f9b1cdfcd6d2)
הוספת פציינט – ניתן להוסיף בטופס הוורוד מתחת רשימת הפציינטים, בלחיצה על Submit תתרחש ההוספה.

עריכת פציינט –  ע"י לחיצה על הכפתור "ערוך" באחד הפציינטים, הנתונים מהפציינט יגיעו אל הטופס למטה. הנה כך: 
![image](https://github.com/shilat-mori/Hadasim0.4/assets/149057922/2cda7991-1967-4116-9168-d1772a0c1b46)
![image](https://github.com/shilat-mori/Hadasim0.4/assets/149057922/7a862737-3e10-4287-9fe8-d0eb4a9b0e6a)

פרטי פציינט – ניתן לנתב ע"י לחיצה על הכפתור "פרטים" באחד מהפציינטים. הנה כך:
![image](https://github.com/shilat-mori/Hadasim0.4/assets/149057922/3c8a9b15-908d-470b-93a8-aed13237eb8f)

![image](https://github.com/shilat-mori/Hadasim0.4/assets/149057922/cdc47437-a560-407c-b428-492042a32015)

מחיקת פציינט – ניתן ללחוץ על הכפתור delete patient שלמטה.


`תלויות חיצוניות`:


DB:

ניתן להריץ את הקובץ HMO_create המצורף כשאילתת SQL ליצירת מסד נתונים.


DB-Server connect:

בפרוייקט צד השרת, יש לשנות את שם תיקיית HMO לשם אחר לפני הרצת החיבור (זאת ע"מ למנוע שגיאות במחיקה).
הגדירו את פרויקט הDAL כ "set startup project".
הריצו את הפקודה הזו בpackage manager console:

Scaffold-DbContext "Server=[myServer];Database=HMO_corona;Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir HMO


! יש להחליף את [myServer] בשם השרת עליו תרצו להריץ את הפרויקט.
אחרי שהחיבור בוצע בהצלחה מחקו את התיקיה שהייתה בעבר קרויה HMO.


Client SetUp:

צרו פרוייקט Angular.
החליפו את תיקיית src בתיקיית src המצורפת.



Client-Server connect:

הריצו את פרויקט הweb API בswagger ובעבור כל כתובת של פונקציה, שנו את הכתובת המתאימה בService  המתאים בפרויקט הAngular .
הריצו את פרויקט הserver, ולאחר מכן הריצו את פרויקט הclient.
Good luck!


`קבצים מצורפים`

מצורף הקובץ "מפרט ארכיטקטוני והסברים" – להבנה מעמיקה יותר.
את תיקיות הקוד תוכלו למצוא:
שרת:

DAL - https://github.com/shilat-mori/Hadasim0.4/tree/main/hadasim/HMO_corona/DAL

BLL - github.com/shilat-mori/Hadasim0.4/tree/main/hadasim/HMO_corona/BLL

WebAPI - https://github.com/shilat-mori/Hadasim0.4/tree/main/hadasim/HMO_corona/HMO_corona

לקוח:

src - https://github.com/shilat-mori/Hadasim0.4/tree/main/hadasim/src

תרגיל 2 מגדלי טוויטר:

Twitter - https://github.com/shilat-mori/Hadasim0.4/tree/main/hadasim/Twitter




כמו כן, קבצי הטקסט של המשימה צורפו בדרייב, מטעמי נוחות גישה ואפשרויות עדכון זמינות יותר.

מפרט ארכיטקטוני גיט -

https://github.com/shilatmori/Hadasim0.4/blob/main/hadasim/%D7%9E%D7%A4%D7%A8%D7%98%20%D7%90%D7%A8%D7%9B%D7%99%D7%98%D7%A7%D7%98%D7%95%D7%A0%D7%99%20%D7%95%D7%94%D7%A1%D7%91%D7%A8%D7%99%D7%9D.txt

מפרט ארכיטקטוני דרייב -

https://docs.google.com/document/d/1wo-B-80BoMe3O-iyIVchl1C5KS9kLidf/edit?usp=sharing&ouid=109534486230259046031&rtpof=true&sd=true


תרגיל 3 דרייב - 
https://docs.google.com/document/d/18zfXWzvj4UB_GNCYhBYMq7HrBhooN3Q3/edit?usp=sharing&ouid=109534486230259046031&rtpof=true&sd=true


