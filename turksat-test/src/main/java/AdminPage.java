import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class AdminPage {
    private WebDriver driver;
    private WebDriverWait wait;
    private final By email = By.id("mat-input-0");
    private final By password = By.id("mat-input-1");
    private final By loginButton = By.xpath("//button[.//span[text()='Log In']]");

    public AdminPage(WebDriver driver, WebDriverWait wait) {
        this.driver = driver;
        this.wait = wait;
    }
    public void setEmail(String emailAsString) throws InterruptedException {
        WebElement emailInput = wait.until(ExpectedConditions.visibilityOfElementLocated(email));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", emailInput); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", emailInput); // JavaScript ile tıklama
        emailInput.clear(); // Bu, varsa önceki metni temizler
        emailInput.sendKeys(emailAsString);
        Thread.sleep(2000);
    }
    public void setPassword(String passwordAsString) throws InterruptedException {
        WebElement passwordInput = wait.until(ExpectedConditions.visibilityOfElementLocated(password));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", passwordInput); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", passwordInput); // JavaScript ile tıklama
        passwordInput.clear(); // Bu, varsa önceki metni temizler
        passwordInput.sendKeys(passwordAsString);
        Thread.sleep(2000);
    }
    public void clickLogin() throws InterruptedException {
        WebElement button = driver.findElement(loginButton);
        button.click();
        Thread.sleep(2000);
    }
}
