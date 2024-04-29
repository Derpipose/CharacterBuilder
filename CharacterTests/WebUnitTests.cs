using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterBuilderWeb.Services; 


namespace CharacterTests
{
    internal class WebUnitTests
    {



        [Order(1)]
        [Test]
        public async Task MakingAndFindingNewChar()
        {


            //GIVEN


            CharacterBusiness business = new CharacterBusiness();


            //WHEN
            //Getlist for compare
            //add character
            //get newlist for compare
            //Get odd character

            //THEN
            //When the character has Id
            //When the character has StatsId

        }
    }
}
