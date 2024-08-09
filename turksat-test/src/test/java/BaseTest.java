import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.TestInstance;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class BaseTest {

    protected WebDriver driver;
    protected AdminPage adminPage;
    protected WebDriverWait wait;
    protected ProductPage productPage;

    @BeforeAll
    public void setUp(){
        System.out.println("Test Başladı");
        System.setProperty("webdriver.chrome.driver", "drivers/chromedriver.exe");
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, Duration.ofSeconds(10)); // WebDriverWait'i burada başlatıyoruz
        driver.get("http://localhost:4200/admin");
        driver.manage().window().fullscreen();
        adminPage = new AdminPage(driver, wait); // WebDriverWait'i AdminPage'e geçiriyoruz
        productPage = new ProductPage(driver,wait);
    }
    @AfterAll
    public void tearDown(){
        driver.quit();
        System.out.println("Test Bitti");
    }
}
