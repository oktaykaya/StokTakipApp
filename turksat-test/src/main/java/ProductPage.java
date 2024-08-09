import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class ProductPage {
    private WebDriver driver;
    private WebDriverWait wait;
    private final By name = By.id("mat-input-2");
    private final By code = By.id("mat-input-3");
    private final By price = By.id("mat-input-4");
    private final By quantity = By.id("mat-input-5");
    private final By feature1 = By.id("mat-input-6");
    private final By feature2 = By.id("mat-input-7");
    private final By createButton = By.xpath("//button[.//span[text()='Create Product']]");

    public ProductPage(WebDriver driver, WebDriverWait wait) {
        this.driver = driver;
        this.wait = wait;
    }

    public void setName(String nameAsString) throws InterruptedException {
        WebElement nameInput = wait.until(ExpectedConditions.visibilityOfElementLocated(name));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", nameInput); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", nameInput); // JavaScript ile tıklama
        nameInput.clear(); // Bu, varsa önceki metni temizler
        nameInput.sendKeys(nameAsString);
        Thread.sleep(2000);
    }
    public void setCode(String codeAsString) throws InterruptedException {
        WebElement codeInput = wait.until(ExpectedConditions.visibilityOfElementLocated(code));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", codeInput); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", codeInput); // JavaScript ile tıklama
        codeInput.clear(); // Bu, varsa önceki metni temizler
        codeInput.sendKeys(codeAsString);
        Thread.sleep(2000);
    }
    public void setPrice(String priceAsString) throws InterruptedException {
        WebElement priceInput = wait.until(ExpectedConditions.visibilityOfElementLocated(price));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", priceInput); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", priceInput); // JavaScript ile tıklama
        priceInput.clear(); // Bu, varsa önceki metni temizler
        priceInput.sendKeys(priceAsString);
        Thread.sleep(2000);
    }
    public void setQuantity(String quantityAsString) throws InterruptedException {
        WebElement quantityInput = wait.until(ExpectedConditions.visibilityOfElementLocated(quantity));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", quantityInput); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", quantityInput); // JavaScript ile tıklama
        quantityInput.clear(); // Bu, varsa önceki metni temizler
        quantityInput.sendKeys(quantityAsString);
        Thread.sleep(2000);
    }
    public void setFeature1(String feature1AsString) throws InterruptedException {
        WebElement feature1Input = wait.until(ExpectedConditions.visibilityOfElementLocated(feature1));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", feature1Input); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", feature1Input); // JavaScript ile tıklama
        feature1Input.clear(); // Bu, varsa önceki metni temizler
        feature1Input.sendKeys(feature1AsString);
        Thread.sleep(2000);
    }
    public void setFeature2(String feature2AsString) throws InterruptedException {
        WebElement feature2Input = wait.until(ExpectedConditions.visibilityOfElementLocated(feature2));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", feature2Input); // Elementi görünür hale getir
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", feature2Input); // JavaScript ile tıklama
        feature2Input.clear(); // Bu, varsa önceki metni temizler
        feature2Input.sendKeys(feature2AsString);
        Thread.sleep(2000);
    }
    public void clickCreate() throws InterruptedException {
        WebElement button = driver.findElement(createButton);
        button.click();
        Thread.sleep(2000);
    }
}
