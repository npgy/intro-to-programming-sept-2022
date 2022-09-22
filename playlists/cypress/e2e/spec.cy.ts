describe('My First Test', () => {
  beforeEach(() => {
    cy.visit('/');
  });
  it('Visits the initial project page', () => {
    cy.contains('Super Playlist App 3000');
  });
  it('allows me to go to the playlists', () => {
    cy.get('[data-test="playlist-link"]').click();

    cy.url().should('match', /playlists\/overview$/);
  });
});
