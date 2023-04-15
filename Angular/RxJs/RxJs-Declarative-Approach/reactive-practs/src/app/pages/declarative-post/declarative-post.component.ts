import { ChangeDetectionStrategy, Component } from '@angular/core';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-declarative-post',
  templateUrl: './declarative-post.component.html',
  styleUrls: ['./declarative-post.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DeclarativePostComponent {
  dPost$ = this.dPostService.post_data;

  constructor(private dPostService: DeclarativePostService) {
  }
}
