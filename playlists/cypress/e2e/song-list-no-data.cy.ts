describe('the song list when there are no songs from the api', () => {
  beforeEach(() => {
    cy.intercept('http://localhost:1337/songs', {
      data: [],
    });
    cy.visit('/playlists/songs');
  });

  it('A warning is displayed that there are no songs', () => {
    cy.get('[data-test="playlists-no-songs-warning"]').should('exist');
  });
  it('should not display the song list', () => {
    cy.get('[data-test="playlists-songs-list"]').should('not.exist');
  });
});
