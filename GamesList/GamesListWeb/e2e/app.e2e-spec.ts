import { MediaListPage } from './app.po';

describe('media-list App', () => {
  let page: MediaListPage;

  beforeEach(() => {
    page = new MediaListPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
