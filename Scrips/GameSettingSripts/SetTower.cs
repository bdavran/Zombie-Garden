using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetTower : MonoBehaviour
{
    public float minPlantDelay = .2f;
    public float timeTillPlant = .1f;
    public int Selected;
    public GameObject[] towers;
    public float[] prices;
    public GameObject Tile;
    private Money moneyscript;
    public  Slider timeSlider;
    private TileTaken tilescript;


    // Use this for initialization
    void Start()
    {
        moneyscript = GameObject.Find("GameLogic").GetComponent<Money>();
        tilescript = Tile.GetComponent<TileTaken>();
    }

    // Update is called once per frame
    void Update()
    {
            timeTillPlant -= Time.deltaTime;
            timeSlider.value = timeTillPlant / minPlantDelay;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//kamerayı yaratılan dünyada screen pointe dönüştürüyoruz
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20))
        {
            
                if (hit.transform.tag == "tile")//eğer tıklanan yer tile a eşit ise
                {
                    Tile = hit.transform.gameObject;//basılan yere towerı koy
                    
                }
            
            if ((Input.GetMouseButtonDown(1) && Tile != null))
            {
                if (hit.collider.tag == "tower")
                {
                    TileTaken tilescript = Tile.GetComponent<TileTaken>();
                    Destroy(hit.collider.gameObject);
                    TileTakensSetFalse();
                }
            }

        }
        else
        {
            Tile = null;//eğer tile değilse temizle ki boş yere tower koyulamasın

        }


        if (Input.GetMouseButtonDown(0) && Tile != null)//mouse sol tuşuna basılmışsa ve tile ise
        {
            TileTaken tilescript = Tile.GetComponent<TileTaken>();
            //tower ve isTaken için generic obje olusturuyoruz ve onlara ulaşmak isitoyurz


            if (!tilescript.isTaken && moneyscript.money >= (int)prices[Selected])//tile alınmamış ise ve seçilen tower modeli sahip olduğumuz paradan yüksek değilse
            {
                if (timeTillPlant <= 0)
                {
                    //tower fiyatını sahip olduğumuz paradan çıkar
                    moneyscript.money -= (int)prices[Selected];
                    Vector3 pos = new Vector3(Tile.transform.position.x, 2F, Tile.transform.position.z); //koymamız gereken tile a tam ortasına gelebilmesi için x ve z yi ortadan alıcak y yi biraz daha yukarısından alıcak tileın
                    tilescript.Tower = (GameObject)Instantiate(towers[Selected], pos, Quaternion.identity);//daha sonra tile a koyulan toweri silmek için kullanacağım 
                    TileTakensSetTrue(); //towerin bulunduğu yeri true yaparsak tekrar üstüne konulmasını engellemiş oluruz
                    timeTillPlant = minPlantDelay;
                } 
                 
                
            }

        }
    }
    public void TileTakensSetFalse()
    {
        TileTaken tilescript = Tile.GetComponent<TileTaken>();
        tilescript.isTaken = false;
    }
    public void TileTakensSetTrue()
    {
        TileTaken tilescript = Tile.GetComponent<TileTaken>();
        tilescript.isTaken = true;
    }

}

	
	


