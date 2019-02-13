using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class StudentBookFactory
    {
        public async StudentBook GetStudentBookInstance() // factory; 3. https://www.codeproject.com/Articles/874246/Understanding-and-Implementing-Factory-Pattern-i-2
        {
            StudentBook studentBook = new StudentBook(await SQLAction.CreateAsync("database.db"));
            await studentBook.loadDefaultData();

            // TODO vytvořit třídu, která bude vracet data - data v ní tedy budou uložena. Právě tato třída sama si interně rozhodně, zda je potřeba požadovaná data v danou chvíli načíst z databáze (ještě je namá načteny), nebo je již načteny má a v tom případě vrátí data ze nějaké své proměnné.
            // TODO factory pattern
            // TODO listView
        }
    }
}
