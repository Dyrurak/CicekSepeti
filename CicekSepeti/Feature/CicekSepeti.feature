Feature: CicekSepeti
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
* 'Chrome' driver ile browser acilir
Scenario: LolafloraSignInPageSuccessfulLoginWithValidEmailAndPassword
	* 'https://www.lolaflora.com/login' sayfasina gidilir
	* Email alanina 'validemail@gmail.com' yazilir
	* Password alanina 'ValidPassword@123' yazilir
	* Sign In butonuna tiklanir
	* Basarili giris yapildigi gorulur

Scenario: LolafloraSignInPageSuccessfulLoginViaFacebook
	* 'https://www.lolaflora.com/login' sayfasina gidilir
	* Sign in with Facebook butonuna tiklanir
	* '1' nolu pencereye gecilir
	* Eposta alanina 'validemail@gmail.com' yazilir
	* Sifre alanina 'ValidPassword@123' yazilir
	* Giris yap butonuna tiklanir
	* '0' nolu pencereye gecilir
	* Basarili giris yapildigi gorulur

Scenario: LolafloraSignInPageUnsuccessfulLoginWithValidEmailAndWrongPassword
	* 'https://www.lolaflora.com/login' sayfasina gidilir
	* Email alanina 'validmail@gmail.com' yazilir
	* Password alanina 'wrongpassword' yazilir
	* Sign In butonuna tiklanir
	* Hatali giris ile ilgili popup mesaji gorulur

Scenario: LolafloraSignInPageUnsuccessfulLoginWithWrongEmailAndValidPassword
	* 'https://www.lolaflora.com/login' sayfasina gidilir
	* Email alanina 'wrong@gmail.com' yazilir
	* Password alanina 'ValidPassword@123' yazilir
	* Sign In butonuna tiklanir
	* Hatali giris ile ilgili popup mesaji gorulur

Scenario: LolafloraSignInPageUnsuccessfulLoginWithEmptyMailAndEmptyPassword
	* 'https://www.lolaflora.com/login' sayfasina gidilir
	* Sign In butonuna tiklanir
	* Email alani altinda 'Required field.' hatasi gorulur
	* Password alani altinda 'Required field.' hatasi gorulur

Scenario: LolafloraSignInPageForgotPasswordSuccessfulSending
	* 'https://www.lolaflora.com/login' sayfasina gidilir
	* Forgot Password butonuna tiklanir
	* Mail alanina 'ciceksepeti@gmail.com' yazilir
	* Send butonuna tiklanir
	* Email gonderiminin basarili oldugu gorulur	