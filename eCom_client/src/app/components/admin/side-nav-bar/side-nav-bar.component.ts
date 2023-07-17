import { Component } from '@angular/core'; 

@Component({
  selector: 'app-side-nav-bar',
  templateUrl: './side-nav-bar.component.html',
  styleUrls: ['./side-nav-bar.component.css']
})
export class SideNavBarComponent {

}
import { NgbNavModule, NgbNavChangeEvent, NgbDropdownModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { NgFor, NgIf } from '@angular/common';

@Component({
	selector: 'app-ngbd-nav',
	standalone: true,
	imports: [NgbNavModule, NgbDropdownModule, NgFor, NgIf, NgbAlertModule],
	templateUrl: './side-nav-bar.component.html',

})
export class NgbdnavBasicComponent {
	//  basic navs
	active = 1;

	// vertical 
	active2 = 'top';


}