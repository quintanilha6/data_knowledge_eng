<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="rss">
    <channel>
      <xsl:for-each select="//item">
        <item>
          <xsl:attribute name="title">
            <xsl:value-of select="title"/>
          </xsl:attribute>
          <xsl:attribute name="id">
            <xsl:value-of select="id"/>
          </xsl:attribute>
          <xsl:attribute name="rating">
            <xsl:value-of select="rating"/>
          </xsl:attribute>
          <xsl:attribute name="poster">
            <xsl:value-of select="poster"/>
          </xsl:attribute>
          <xsl:attribute name="year">
            <xsl:value-of select="year"/>
          </xsl:attribute>
        </item>
      </xsl:for-each>
    </channel>
  </xsl:template>
</xsl:stylesheet>
