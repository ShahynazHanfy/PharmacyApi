import { Component } from '@angular/core';
import { User } from './Models/user.model';
import { Router } from '@angular/router';
import { AuthenticationService } from './Services/authentication.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SMC-UI';
 

  constructor(){
   
  }
    
  
}
