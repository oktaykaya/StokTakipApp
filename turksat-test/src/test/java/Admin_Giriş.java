import org.junit.jupiter.api.Order;
import org.junit.jupiter.api.Test;

public class Admin_Giriş extends BaseTest {


    @Test
    @Order(1)
    public void AdminLogin() throws InterruptedException  {
        adminPage.setEmail("oktay@turksat.com");
        adminPage.setPassword("123");
        adminPage.clickLogin();
    }

    @Test
    @Order(2)
    public void AddProduct() throws InterruptedException  {
        productPage.setName("Galaxy A15");
        productPage.setCode("SAMSUNG 68GB/128GB Akıllı Telefon Light Mavi");
        productPage.setPrice("7999");
        productPage.setQuantity("10");
        productPage.setFeature1("128 GB");
        productPage.setFeature2("Mediatek Helio G99 (MT6789) 2.2GHz");
        productPage.clickCreate();
    }



}
