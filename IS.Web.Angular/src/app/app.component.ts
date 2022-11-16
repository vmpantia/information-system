import { Component } from '@angular/core';
import { faGauge, faCodePullRequest, faUser, faBuilding, faLocationDot } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'IS.Web.Angular';
  faGauge = faGauge;
  faCodePullRequest = faCodePullRequest;
  faUser = faUser;
  faBuilding = faBuilding;
  faLocationDot = faLocationDot
}
