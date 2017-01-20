<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="movies">
    <movies>
      <xsl:for-each select="//movie">
        <movie>
          <xsl:attribute name="rating">
            <xsl:value-of select="rating"/>
          </xsl:attribute>
          <xsl:attribute name="title">
            <xsl:value-of select="title"/>
          </xsl:attribute>
          <xsl:attribute name="year">
            <xsl:value-of select="year"/>
          </xsl:attribute>
          <xsl:attribute name="idIMDB">
            <xsl:value-of select="idIMDB"/>
          </xsl:attribute>
          <xsl:attribute name="urlPoster">
            <xsl:value-of select="urlPoster"/>
          </xsl:attribute>
          <xsl:for-each select="movie">
            <genres>
              <xsl:attribute name="genre">
                <xsl:value-of select="genre"/>
              </xsl:attribute>
            </genres>
          </xsl:for-each>
        </movie>
      </xsl:for-each>
    </movies>
  </xsl:template>
</xsl:stylesheet>