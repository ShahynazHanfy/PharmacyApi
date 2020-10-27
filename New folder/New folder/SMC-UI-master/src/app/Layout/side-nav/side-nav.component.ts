import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { User } from 'src/app/Models/user.model';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {

  href:any;
  Lang: any;
  currentUser : User;
  
  constructor( public translate: TranslateService , private router: Router
     , private auth : AuthenticationService) {
    this.auth.currentUser.subscribe(x => this.currentUser = x);
    this.href = '';
    translate.addLangs(['en', 'ar']);
    translate.setDefaultLang('en');
    const browserLang = translate.getBrowserLang();
    translate.use(browserLang.match(/en|ar/) ? browserLang : 'en');
   }

  ngOnInit() {
  }

  changeLang(lang) {
    
    this.translate.use(lang);
    this.Lang = lang;
    this.href = this.router.url;
  }

  Logout()
  {
    console.log("logout clicked");
    this.auth.LogOut();
    this.router.navigate(['/Login']);
  }

}
